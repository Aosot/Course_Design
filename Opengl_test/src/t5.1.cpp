//EBO和失败反馈

#include<iostream>
#include<glad/glad.h>
#include<GLFW/glfw3.h>

float vertices[]={
    0.5f,0.5f,0.0f,
    0.0f,0.5f,0.0f,
    0.5f,0.0f,0.0f,
    0.0f,0.0f,0.0f
};

int indices[]={
    0,1,2,
    1,2,3
};

char *vss="#version 330 core\n"
"layout(location=0)in vec3 aPos;\n"
"void main(){\n"
"   gl_Position=vec4(aPos,1.0f);\n"
"}\0";

char *fss="#version 330 core\n"
"out vec4 FragColor;\n"
"void main(){\n"
"   FragColor=vec4(0.7f,0.5f,0.3f,1.0f);\n"
"}\0";

int success;
char infoLog[512];

int main()
{
    glfwInit();

    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR,3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR,3);
    glfwWindowHint(GLFW_OPENGL_PROFILE,GLFW_OPENGL_CORE_PROFILE);
    
    GLFWwindow* window=glfwCreateWindow(800,600,"t6.1",NULL,NULL);
    if(window==NULL)
    {
        std::cout<<"Failed to create glfw window!"<<std::endl;
        glfwTerminate();
        return -1;
    }
    glfwMakeContextCurrent(window);
    if(!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
    {
        std::cout<<"Failed to load glad procedures!"<<std::endl;
        return -2;
    }
    glViewport(0,0,800,600);

    unsigned int vertexShader=glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vertexShader,1,&vss,NULL);////////////
    glCompileShader(vertexShader);
    glGetShaderiv(vertexShader,GL_COMPILE_STATUS,&success);
    if(!success)
    {
        glGetShaderInfoLog(vertexShader,512,NULL,infoLog);
        std::cout<<"顶点着色器编译失败！\n"<<infoLog<<std::endl;
    }

    unsigned int fragmentShader=glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fragmentShader,1,&fss,NULL);
    glCompileShader(fragmentShader);
    glGetShaderiv(fragmentShader,GL_COMPILE_STATUS,&success);
    if(!success)
    {
        glGetShaderInfoLog(fragmentShader,512,NULL,infoLog);
        std::cout<<"片段着色器编译失败！\n"<<infoLog<<std::endl;
    }

    unsigned int shaderProgram=glCreateProgram();
    glAttachShader(shaderProgram,vertexShader);
    glAttachShader(shaderProgram,fragmentShader);
    glLinkProgram(shaderProgram);
    glGetProgramiv(shaderProgram,GL_LINK_STATUS,&success);
    if(!success)
    {
        glGetProgramInfoLog(shaderProgram,512,NULL,infoLog);
        std::cout<<"程序链接失败！\n"<<infoLog<<std::endl;
    }
    glDeleteShader(vertexShader);
    glDeleteShader(fragmentShader);

    unsigned int VBO;
    glGenBuffers(1,&VBO);
    glBindBuffer(GL_ARRAY_BUFFER,VBO);
    glBufferData(GL_ARRAY_BUFFER,sizeof(vertices),vertices,GL_STATIC_DRAW);//////////////
    
    unsigned int VAO;
    glGenVertexArrays(1,&VAO);
    glBindVertexArray(VAO);
    glVertexAttribPointer(0,3,GL_FLOAT,GL_FALSE,sizeof(float)*3,(void*)0);//////////////
    glEnableVertexAttribArray(0);

    unsigned int EBO;
    glGenBuffers(1,&EBO);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER,EBO);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER,sizeof(indices),indices,GL_STATIC_DRAW);

    while(!glfwWindowShouldClose(window))
    {
        glClearColor(0.4f,0.6f,0.6f,1.0f);
        glClear(GL_COLOR_BUFFER_BIT);

        glUseProgram(shaderProgram);
        glDrawElements(GL_TRIANGLES,6,GL_UNSIGNED_INT,0);

        glfwSwapBuffers(window);
        glfwPollEvents();
    }

    glfwTerminate();
    return 0;
}