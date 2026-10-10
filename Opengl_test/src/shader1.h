#ifndef SHADER_H
#define SHADER_H

#include<iostream>
#include<glad/glad.h>
#include<fstream>

class Shader
{
public:
    unsigned int ID;

    Shader(const std::string& vsPath,const std::string& fsPath)
    {
        std::fstream vsFile,fsFile;
        std::string vsSource;
        std::string fsSource;
        std::string current;
        const char *vsCode;
        const char *fsCode;

        vsFile.open(vsPath);
        while(getline(vsFile,current))
        {
            vsSource+=current;
            vsSource+='\n';
        }
        
        fsFile.open(fsPath);
        while(getline(fsFile,current))
        {
            fsSource+=current;
            fsSource+='\n';
        }
        
        vsCode=vsSource.c_str();
        fsCode=fsSource.c_str();

        unsigned int vs,fs;
        vs=glCreateShader(GL_VERTEX_SHADER);
        glShaderSource(vs,1,&vsCode,NULL);
        glCompileShader(vs);
        fs=glCreateShader(GL_FRAGMENT_SHADER);
        glShaderSource(fs,1,&fsCode,NULL);
        glCompileShader(fs);
        ID=glCreateProgram();
        glAttachShader(ID,vs);
        glAttachShader(ID,fs);
        glLinkProgram(ID);
        glDeleteShader(vs);
        glDeleteShader(fs);
    }

    void use()
    {
        glUseProgram(ID);
    }

};

#endif