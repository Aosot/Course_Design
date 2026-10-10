//着色器头文件封装 shader1.h

#include<iostream>
#include<glad/glad.h>
#include<GLFW/glfw3.h>
#include"shader1.h"

float vertices[]={
    0.5f,0.0f,1.0f,
    0.0f,0.5f,1.0f,
    -0.5f,0.0f,1.0f
};

int main()
{
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR,3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR,3);
    glfwWindowHint(GLFW_OPENGL_PROFILE,GLFW_OPENGL_CORE_PROFILE);
    GLFWwindow* window=glfwCreateWindow(800,600,"t3.1",NULL,NULL);
    if(window==NULL)
    {
        std::cout<<"Failed to create GLFWwindow!\n"<<std::endl;
        glfwTerminate();
        return -1;
    }
    glfwMakeContextCurrent(window);
    if(!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
    {
        std::cout<<"Failed to load procedure!\n"<<std::endl;
        return -2;
    }
    glViewport(0,0,800,600);

    Shader s("C:/data/Projects/Opengl/ShaderSource/vertex.vs","C:/data/Projects/Opengl/ShaderSource/fragment.fs");
    unsigned int VBO;
    glGenBuffers(1,&VBO);
    glBindBuffer(GL_ARRAY_BUFFER,VBO);
    glBufferData(GL_ARRAY_BUFFER,sizeof(vertices),vertices,GL_STATIC_DRAW);
    unsigned int VAO;
    glGenVertexArrays(1,&VAO);
    glBindVertexArray(VAO);
    glVertexAttribPointer(0,3,GL_FLOAT,GL_FALSE,sizeof(float)*3,(void*)0);
    glEnableVertexAttribArray(0);
    while(!glfwWindowShouldClose(window))
    {
        glClearColor(0.6f,0.2f,0.1f,1.0f);
        glClear(GL_COLOR_BUFFER_BIT);

        s.use();
        glDrawArrays(GL_TRIANGLES,0,3);

        glfwSwapBuffers(window);
        glfwPollEvents();
    }
    glfwTerminate();
    return 0;
}