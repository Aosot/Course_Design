#include<iostream>
#include<glad/glad.h>
#include<GLFW/glfw3.h>
#define STB_IMAGE_IMPLEMENTATION
#include"stb_image.h"
#include<glm/glm.hpp>
#include<glm/gtc/matrix_access.hpp>
#include<glm/gtc/type_ptr.hpp>


float vertices[]={
    -0.5f,-0.5f,0.0f,0.0f,0.0f,
    0.5f,-0.5f,0.0f,1.0f,0.0f,
    -0.5f,0.5f,0.0f,0.0f,1.0f,
    0.5f,0.5f,0.0f,1.0f,1.0f
};

int indices[]={
    0,1,2,
    1,2,3
};

const char* vss="#version 330 core\n"
"layout(location=0) in vec3 aPos;\n"
"layout(location=1) in vec2 aTex;\n"
"out vec2 myTexture;\n"
"uniform mat4 transform;\n"
"void main(){\n"
"   gl_Position=transform*vec4(aPos,1.0f);\n"
"   myTexture=aTex;\n"
"}\0";

const char* fss="#version 330 core\n"
"uniform vec4 myColor;\n"
"in vec2 myTexture;\n"
"out vec4 FragColor;\n"
"uniform sampler2D ourTexture;\n"
"void main(){\n"
"   FragColor=texture(ourTexture,myTexture)*myColor;\n"
"}\0";

int success;
char infoLog[512];

int main()
{
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR,3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR,3);
    glfwWindowHint(GLFW_OPENGL_PROFILE,GLFW_OPENGL_CORE_PROFILE);
    GLFWwindow* window=glfwCreateWindow(800,600,"t6.3",NULL,NULL);
    if(window==NULL)
    {
        std::cout<<"Failed to create glfw window"<<std::endl;
        glfwTerminate();
        return -1;
    }
    glfwMakeContextCurrent(window);
    if(!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
    {
        std::cout<<"Failed to create glad procedure"<<std::endl;
        return -2;
    }
    glViewport(0,0,800,600);

    unsigned int vs=glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vs,1,&vss,NULL);
    glCompileShader(vs);
    glGetShaderiv(vs,GL_COMPILE_STATUS,&success);
    if(!success)
    {
        glGetShaderInfoLog(vs,512,NULL,infoLog);
        std::cout<<"顶点着色器编译失败！\n"<<infoLog<<std::endl;
    }

    unsigned int fs=glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fs,1,&fss,NULL);
    glCompileShader(fs);
    glGetShaderiv(fs,GL_COMPILE_STATUS,&success);
    if(!success)
    {
        glGetShaderInfoLog(fs,512,NULL,infoLog);
        std::cout<<"片段着色器编译失败！\n"<<infoLog<<std::endl;
    }
    
    unsigned int sp=glCreateProgram();
    glAttachShader(sp,vs);
    glAttachShader(sp,fs);
    glLinkProgram(sp);
    glGetProgramiv(sp,GL_LINK_STATUS,&success);
    if(!success)
    {
        glGetProgramInfoLog(sp,512,NULL,infoLog);
    }
    glDeleteShader(vs);
    glDeleteShader(fs);

    unsigned int VBO;
    glGenBuffers(1,&VBO);
    glBindBuffer(GL_ARRAY_BUFFER,VBO);
    glBufferData(GL_ARRAY_BUFFER,sizeof(vertices),vertices,GL_STATIC_DRAW);

    unsigned int VAO;
    glGenVertexArrays(1,&VAO);
    glBindVertexArray(VAO);
    glVertexAttribPointer(0,3,GL_FLOAT,GL_FALSE,sizeof(float)*5,(void*)0);
    glVertexAttribPointer(1,2,GL_FLOAT,GL_FALSE,sizeof(float)*5,(void*)(sizeof(float)*3));
    glEnableVertexAttribArray(0);
    glEnableVertexAttribArray(1);

    unsigned int EBO;
    glGenBuffers(1,&EBO);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER,EBO);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER,sizeof(indices),indices,GL_STATIC_DRAW);

    unsigned int texture;
    glGenTextures(1,&texture);
    glBindTexture(GL_TEXTURE_2D,texture);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_WRAP_S,GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_WRAP_T,GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MAG_FILTER,GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MIN_FILTER,GL_LINEAR);

    stbi_set_flip_vertically_on_load(true);
    int width,height,nrChannels;
    unsigned char *data=stbi_load("anime.jpg",&width,&height,&nrChannels,0);
    if(data==NULL)
    {
        glfwTerminate();
        return -3;
    }
    glTexImage2D(GL_TEXTURE_2D,0,GL_RGB,width,height,0,GL_RGB,GL_UNSIGNED_BYTE,data);
    glGenerateMipmap(GL_TEXTURE_2D);
    stbi_image_free(data);

    while(!glfwWindowShouldClose(window))
    {
        glClearColor(0.4f,0.4f,0.6f,1.0f);
        glClear(GL_COLOR_BUFFER_BIT);

        glUseProgram(sp);
        glBindVertexArray(VAO);
        glBindTexture(GL_TEXTURE_2D,texture);

        float time=glfwGetTime();
        glm::mat4 trans=glm::mat4(1.0f);
        trans=glm::rotate(trans,time,glm::vec3(0.0f,0.0f,1.0f));

        unsigned int location1=glGetUniformLocation(sp,"myColor");
        unsigned int location2=glGetUniformLocation(sp,"transform");
        glUniform4f(location1,1.0f,((sin(time)+1)*0.5),1.0f,0.5f);
        glUniformMatrix4fv(location2,1,GL_FALSE,glm::value_ptr(trans));
        
        glDrawElements(GL_TRIANGLES,6,GL_UNSIGNED_INT,0);

        glfwSwapBuffers(window);
        glfwPollEvents();
    }
    glfwTerminate();
    return 0;
}