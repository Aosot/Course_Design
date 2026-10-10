//EBO

#include<iostream>
#include<glad\glad.h>
#include<GLFW\glfw3.h>

float vertices[] = {
    0.5f,0.5f,0.0f,
    0.5f,-0.5f,0.0f,
    -0.5f,0.5f,0.0f,
    -0.5f,-0.5f,0.0f
};

int index[]={
    0,1,2,
    1,2,3
};

char *vertexShaderSource=
    "#version 330 core\n"
    "layout(location=0)in vec3 aPos;\n"
    "void main()\n"
    "{\n"
    "   gl_Position=vec4(aPos,1.0f);\n"
    "}\0";

char *fragmentShaderSource=
    "#version 330 core\n"
    "out vec4 FragColor;\n"
    "void main()\n"
    "{\n"
    "   FragColor=vec4(1.0f,0.5f,0.2f,1.0f);\n"
    "}\0";
    
void check(GLFWwindow* window)
{
    if(glfwGetKey(window,GLFW_KEY_ESCAPE)==GLFW_PRESS)
    {
        glfwSetWindowShouldClose(window,true);
    }
}

int main()
{
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR,3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR,3);
    glfwWindowHint(GLFW_OPENGL_PROFILE,GLFW_OPENGL_CORE_PROFILE);

    GLFWwindow* window=glfwCreateWindow(800,600,"t1",NULL,NULL);
    if(window==NULL)
    {
        std::cout<<"Failed to create glfw window"<<std::endl;
        glfwTerminate();
        return -1;
    }
    glfwMakeContextCurrent(window);
    if(!(gladLoadGLLoader((GLADloadproc)glfwGetProcAddress)))
    {
        std::cout<<"Failed to load glad procedure"<<std::endl;
        return -1;
    }
    glViewport(0,0,800,600);

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
    glVertexAttribPointer(0,3,GL_FLOAT,GL_FALSE,sizeof(float)*3,(void*)0);
    glEnableVertexAttribArray(0);

    unsigned int EBO;
    glGenBuffers(1,&EBO);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER,EBO);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER,sizeof(index),index,GL_STATIC_DRAW);

    while(!glfwWindowShouldClose(window))
    {
        glClearColor(0.6f,0.2f,0.1f,1.0f);
        glClear(GL_COLOR_BUFFER_BIT);

        check(window);

        glUseProgram(shaderProgram);
        glDrawElements(GL_TRIANGLES,6,GL_UNSIGNED_INT,0);

        glfwSwapBuffers(window);
        glfwPollEvents();
    }
    glfwTerminate();
    return 0;
}