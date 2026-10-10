//多顶点 不同VAOVBO、着色器

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

const char * vss1="#version 330 core\n"
"layout(location=0)in vec3 aPos;\n"
"void main(){\n"
"   gl_Position=vec4(aPos.x*1.2,aPos.yz,1.0f);\n"
"}\0";

const char * vss2="#version 330 core\n"
"layout(location=0)in vec3 aPos;\n"
"void main(){\n"
"   gl_Position=vec4(aPos.x*0.5,aPos.y,aPos.z,1.0f);\n"
"}\0";


const char * fss1="#version 330 core\n"
"out vec4 FragColor;\n"
"void main(){\n"
"   FragColor=vec4(0.2f,0.5f,0.7f,1.0f);\n"
"}\0";

const char * fss2="#version 330 core\n"
"out vec4 FragColor;\n"
"void main(){\n"
"   FragColor=vec4(0.7f,0.5f,0.2f,1.0f);\n"
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

    unsigned int fs1=glCreateShader(GL_FRAGMENT_SHADER); 
    glShaderSource(fs1,1,&fss1,NULL);
    glCompileShader(fs1);

    unsigned int vs1=glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vs1,1,&vss1,NULL);
    glCompileShader(vs1);

    unsigned int Shaderprogram1=glCreateProgram();
    glAttachShader(Shaderprogram1,vs1);
    glAttachShader(Shaderprogram1,fs1); 
    glLinkProgram(Shaderprogram1);
    glDeleteShader(vs1);
    glDeleteShader(fs1);


    unsigned int fs2=glCreateShader(GL_FRAGMENT_SHADER); 
    glShaderSource(fs2,1,&fss2,NULL);
    glCompileShader(fs2);

    unsigned int vs2=glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vs2,1,&vss2,NULL);
    glCompileShader(vs2);

    unsigned int Shaderprogram2=glCreateProgram();
    glAttachShader(Shaderprogram2,vs2);
    glAttachShader(Shaderprogram2,fs2); 
    glLinkProgram(Shaderprogram2);
    glDeleteShader(vs2);
    glDeleteShader(fs2);


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

        glUseProgram(Shaderprogram1);
        glBindVertexArray(VAO1);
        glDrawArrays(GL_TRIANGLES,0,3);
        glUseProgram(Shaderprogram2);
        glBindVertexArray(VAO2);
        glDrawArrays(GL_TRIANGLES,0,3);

        glfwSwapBuffers(window);
        glfwPollEvents();
    }
    glfwTerminate();
    return 0;
}