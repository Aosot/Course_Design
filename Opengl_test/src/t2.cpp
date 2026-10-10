//多顶点 同着色器不同VAOVBO

#include<iostream>
#include<glad/glad.h>
#include<GLFW/glfw3.h>

float vertices1[]={
    0.5f,-0.5f,0.0f,
    -0.5f,-0.5f,0.0f,
    0.0f,0.0f,0.0f
};

float vertices2[]={
    0.5f,0.5f,0.0f,
    -0.5f,0.5f,0.0f,
    0.0f,0.0f,0.0f
};

const char * vss="#version 330 core\n"
"layout(location=0)in vec3 aPos;\n"
"void main(){\n"
"   gl_Position=vec4(aPos,1.0f);\n"
"}\0";

const char * fss="#version 330 core\n"
"out vec4 FragColor;\n"
"void main(){\n"
"   FragColor=vec4(0.2f,0.5f,0.7f,1.0f);\n"
"}\0";

int main()
{
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR,3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR,3);
    glfwWindowHint(GLFW_OPENGL_PROFILE,GLFW_OPENGL_CORE_PROFILE);
    GLFWwindow * window =glfwCreateWindow(800,600,"t2",NULL,NULL);
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

    unsigned int fs=glCreateShader(GL_FRAGMENT_SHADER); 
    glShaderSource(fs,1,&fss,NULL);
    glCompileShader(fs);

    unsigned int vs=glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vs,1,&vss,NULL);
    glCompileShader(vs);

    unsigned int Shaderprogram=glCreateProgram();
    glAttachShader(Shaderprogram,vs);
    glAttachShader(Shaderprogram,fs); 
    glLinkProgram(Shaderprogram);
    glDeleteShader(vs);
    glDeleteShader(fs);

    unsigned int VBO1;
    glGenBuffers(1,&VBO1);
    glBindBuffer(GL_ARRAY_BUFFER,VBO1);
    glBufferData(GL_ARRAY_BUFFER,sizeof(vertices1),vertices1,GL_STATIC_DRAW);

    unsigned int VAO1;
    glGenVertexArrays(1,&VAO1);
    glBindVertexArray(VAO1);
    glVertexAttribPointer(0,3,GL_FLOAT,GL_FALSE,sizeof(float)*3,(void*)0);
    glEnableVertexAttribArray(0);

    unsigned int VBO2;
    glGenBuffers(1,&VBO2);
    glBindBuffer(GL_ARRAY_BUFFER,VBO2);
    glBufferData(GL_ARRAY_BUFFER,sizeof(vertices2),vertices2,GL_STATIC_DRAW);

    unsigned int VAO2;
    glGenVertexArrays(1,&VAO2);
    glBindVertexArray(VAO2);
    glVertexAttribPointer(0,3,GL_FLOAT,GL_FALSE,sizeof(float)*3,(void*)0);
    glEnableVertexAttribArray(0);

    while(!glfwWindowShouldClose(window))
    {
        glClearColor(0.5f,0.5f,0.5f,1.0f);
        glClear(GL_COLOR_BUFFER_BIT);

        glUseProgram(Shaderprogram);
        glBindVertexArray(VAO1);
        glDrawArrays(GL_TRIANGLES,0,3);
        glBindVertexArray(VAO2);
        glDrawArrays(GL_TRIANGLES,0,3);

        glfwSwapBuffers(window);
        glfwPollEvents();
    }
    glfwTerminate();
    return 0;
}