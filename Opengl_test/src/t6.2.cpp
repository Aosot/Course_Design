//旋转功能

#include<iostream>
#include<glad/glad.h>
#include<GLFW/glfw3.h>
#include<glm/glm.hpp>
#include<glm/gtc/matrix_access.hpp>
#include<glm/gtc/type_ptr.hpp>
#define STB_IMAGE_IMPLEMENTATION
#include"stb_image.h"

float vertices[]={
    -0.5f,-0.5f,0.0f,0.0f,0.0f,
    -0.5f,0.5f,0.0f,0.0f,1.0f,
    0.5f,-0.5f,0.0f,1.0f,0.0f,
    0.5f,0.5f,0.0f,1.0f,1.0f
};

int indices[]={
    0,1,2,
    1,2,3
};

const char *vertexShaderSource="#version 330 core\n"
"layout(location=0)in vec3 aPos;\n"
"layout(location=1)in vec2 aTex;\n"
"out vec2 myTexture;\n"
"uniform mat4 transform;\n"
"void main(){\n"
"   gl_Position=transform*vec4(aPos,1.0f);\n"
"   myTexture=aTex;\n"
"}\0";

const char *fragmentShaderSource="#version 330 core\n"
"out vec4 FragColor;\n"
"in vec2 myTexture;\n"
"uniform sampler2D ourTexture;\n"
"void main(){\n"
"   FragColor=texture(ourTexture,myTexture);\n"
"}\0";

int main()
{
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR,3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR,3);
    glfwWindowHint(GLFW_OPENGL_PROFILE,GLFW_OPENGL_CORE_PROFILE);
    GLFWwindow* window=glfwCreateWindow(800,600,"t6.2",NULL,NULL);
    if(window==NULL)
    {
        std::cout<<"Failed to create glfw window"<<std::endl;
        glfwTerminate();
        return -1;
    }
    glfwMakeContextCurrent(window);
    if(!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
    {
        std::cout<<"Failed to load glad procedures"<<std::endl;
        return -2;
    }
    glViewport(0,0,600,600);

    unsigned int vertexShader=glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vertexShader,1,&vertexShaderSource,NULL);
    glCompileShader(vertexShader);

    unsigned int fragmentShader=glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fragmentShader,1,&fragmentShaderSource,NULL);
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
    glVertexAttribPointer(0,3,GL_FLOAT,GL_FALSE,sizeof(float)*5,(void*)0);
    glVertexAttribPointer(1,2,GL_FLOAT,GL_FALSE,sizeof(float)*5,(void*)(sizeof(float)*3));
    glEnableVertexAttribArray(0);
    glEnableVertexAttribArray(1);

    unsigned int EBO;
    glGenBuffers(1,&EBO);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER,EBO);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER,sizeof(indices),indices,GL_STATIC_DRAW);

    unsigned int Tex;
    glGenTextures(1,&Tex);
    glBindTexture(GL_TEXTURE_2D,Tex);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_WRAP_S,GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_WRAP_T,GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MIN_FILTER,GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MAG_FILTER,GL_LINEAR);

    int width,height,nrChannels;
    stbi_set_flip_vertically_on_load(true);
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

        float time=glfwGetTime();
        glm::mat4 trans=glm::mat4(1.0f);
        trans=glm::rotate(trans,time,glm::vec3(0.0f,0.0f,1.0f));

        glUseProgram(shaderProgram);

        int transformLoc=glGetUniformLocation(shaderProgram,"transform");
        glUniformMatrix4fv(transformLoc,1,GL_FALSE,glm::value_ptr(trans));
        glDrawElements(GL_TRIANGLES,6,GL_UNSIGNED_INT,0);

        glfwSwapBuffers(window);
        glfwPollEvents();
    }
    glfwTerminate();
    return 0;
}