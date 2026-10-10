#include<iostream>
#include<glm/glm.hpp>
#include<glm/gtc/matrix_access.hpp>
#include<glm/gtc/type_ptr.hpp>

int main()
{
    glm::vec4 vec(1.0f,0.0f,0.0f,1.0f);
    glm::mat4 trans=glm::mat4(1.0f);
    trans=glm::scale(trans,glm::vec3(2.0f,2.0f,2.0f));
    trans=glm::rotate(trans,glm::radians(90.0f),glm::vec3(0.0f,0.0f,1.0f));
    trans=glm::translate(trans,glm::vec3(1.0f,1.0f,0.0f));
    vec=trans*vec;
    std::cout<<vec.x<<vec.y<<vec.z<<std::endl;
    return 0;
}



