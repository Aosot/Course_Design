//图片插入

#include<iostream>
#include<glad/glad.h>
#include<GLFW/glfw3.h>
#define STB_IMAGE_IMPLEMENTATION
#include"stb_image.h"

float vertices[] = {
     0.5f,0.5f,0.0f, 1.0f,0.0f,0.0f, 1.0f,1.0f,
     0.5f,-0.5f,0.0f, 0.0f,1.0f,0.0f, 1.0f,0.0f,
    -0.5f,-0.5f,0.0f, 0.0f,0.0f,1.0f, 0.0f,0.0f,
    -0.5f,0.5f,0.0f, 1.0f,0.0f,0.0f, 0.0f,1.0f
};

int index[]={
    0,1,3,
    1,2,3
};

const char* vss=
"#version 330 core\n"
"layout(location=0)in vec3 aPos;\n"
"layout(location=1)in vec3 aCol;\n"
"layout(location=2)in vec2 aTex;\n"
"out vec4 myColor;\n"
"out vec2 myTexture;\n"
"void main(){\n"
"   gl_Position=vec4(aPos,1.0f);\n"
"   myColor=vec4(aCol,1.0f);\n"
"   myTexture=aTex;\n"
"}\0";

const char* fss=
"#version 330 core\n"
"out vec4 FragColor;\n"
"in vec4 myColor;\n"
"in vec2 myTexture;\n"
"uniform sampler2D ourTexture;\n"
"void main(){\n"
"    FragColor=texture(ourTexture,myTexture)*myColor;\n"
"}\0";

int main()
{
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR,3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR,3);
    glfwWindowHint(GLFW_OPENGL_PROFILE,GLFW_OPENGL_CORE_PROFILE);
    GLFWwindow* window=glfwCreateWindow(800,600,"t4",NULL,NULL);
    if(window==NULL)
    {
        std::cout<<"Failed to create GLFW window!"<<std::endl;
        glfwTerminate();
        return -1;
    }
    glfwMakeContextCurrent(window);
    if(!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
    {
        std::cout<<"Failed to load glad procedures!"<<std::endl;
        return -1;
    }
    glViewport(0,0,800,600);

    unsigned int vertexShader=glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vertexShader,1,&vss,NULL);
    glCompileShader(vertexShader);

    unsigned int fragmentShader=glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fragmentShader,1,&fss,NULL);
    glCompileShader(fragmentShader);

    unsigned int shaderProgram=glCreateProgram();
    glAttachShader(shaderProgram,vertexShader);
    glAttachShader(shaderProgram,fragmentShader);
    glLinkProgram(shaderProgram);
    glDeleteShader(vertexShader);
    glDeleteShader(fragmentShader);

    unsigned int VBO;
    glGenBuffers(1,&VBO);
    glBindBuffer(GL_ARRAY_BUFFER,VBO);
    glBufferData(GL_ARRAY_BUFFER,sizeof(vertices),vertices,GL_STATIC_DRAW);

    unsigned int VAO;
    glGenVertexArrays(1,&VAO);
    glBindVertexArray(VAO);
    glVertexAttribPointer(0,3,GL_FLOAT,GL_FALSE,sizeof(float)*8,(void*)0);
    glVertexAttribPointer(1,3,GL_FLOAT,GL_FALSE,sizeof(float)*8,(void*)12);
    glVertexAttribPointer(2,2,GL_FLOAT,GL_FALSE,sizeof(float)*8,(void*)24);
    glEnableVertexAttribArray(0);
    glEnableVertexAttribArray(1);
    glEnableVertexAttribArray(2);

    unsigned int EBO;
    glGenBuffers(1,&EBO);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER,EBO);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER,sizeof(index),index,GL_STATIC_DRAW);

    unsigned int texture;
    glGenTextures(1,&texture);
    glBindTexture(GL_TEXTURE_2D,texture);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_WRAP_S,GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_WRAP_T,GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MIN_FILTER,GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MAG_FILTER,GL_LINEAR);

    int width,height,nrChannels;
    stbi_set_flip_vertically_on_load(true);
    unsigned char *data = stbi_load("anime.jpg",&width,&height,&nrChannels,0); 
    if(data==NULL)
    {
        glfwTerminate();
        return 0;
    }
    glTexImage2D(GL_TEXTURE_2D,0,GL_RGB,width,height,0,GL_RGB,GL_UNSIGNED_BYTE,data);
    glGenerateMipmap(GL_TEXTURE_2D);
    stbi_image_free(data);

    while(!glfwWindowShouldClose(window))
    {
        glClearColor(0.3f,0.3f,0.3f,1.0f);
        glClear(GL_COLOR_BUFFER_BIT);

        glUseProgram(shaderProgram);
        glBindVertexArray(VAO);
        glBindTexture(GL_TEXTURE_2D,texture);
        glDrawElements(GL_TRIANGLES,6,GL_UNSIGNED_INT,0);

        glfwSwapBuffers(window);
        glfwPollEvents();
    }
    glfwTerminate();
    return 0;
}












