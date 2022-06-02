# Azure Dapr for .NET Developers Part 1
This is the repository for the LinkedIn Learning course Azure Dapr for .NET Developers Part 1. The full course is available from [LinkedIn Learning][lil-course-url].

![Azure Dapr for .NET Developers Part 1][lil-thumbnail-url] 

Azure Dapr can help .NET developers solve several challenges that they face when building distributed applications. In this course, Rodrigo Díaz Concha shows you how to build distributed applications and microservices easily with Dapr.  Rodrigo begins by introducing Dapr as a portable, event-driven runtime for creating distributed applications in the cloud. He explains the sidecar pattern and the different components and tools that you will use in Dapr. Rodrigo walks you through preparing your development environment, then covers some of the most important building blocks in Dapr. This course focuses on publish and subscribe (pub/sub), service invocation, state management, and bindings.

## Instructions
This repository has branches for each of the videos in the course. You can use the branch pop up menu in github to switch to a specific branch and take a look at the course at that stage, or you can add `/tree/BRANCH_NAME` to the URL to go to the branch you want to access.

## Branches
The branches are structured to correspond to the videos in the course. The naming convention is `CHAPTER#_MOVIE#`. As an example, the branch named `02_03` corresponds to the second chapter and the third video in that chapter. 
Some branches will have a beginning and an end state. These are marked with the letters `b` for "beginning" and `e` for "end". The `b` branch contains the code as it is at the beginning of the movie. The `e` branch contains the code as it is at the end of the movie. The `main` branch holds the final state of the code when in the course.

When switching from one exercise files branch to the next after making changes to the files, you may get a message like this:

    error: Your local changes to the following files would be overwritten by checkout:        [files]
    Please commit your changes or stash them before you switch branches.
    Aborting

To resolve this issue:
	
    Add changes to git using this command: git add .
	Commit changes using this command: git commit -m "some message"

### Instructor

Rodrigo Díaz Concha 
                            


                            

Check out my other courses on [LinkedIn Learning](https://www.linkedin.com/learning/instructors/rodrigo-diaz-concha).

[lil-course-url]: https://www.linkedin.com/learning/azure-dapr-for-dot-net-developers-part-1
[lil-thumbnail-url]: https://cdn.lynda.com/course/2469004/2469004-1653669319069-16x9.jpg
