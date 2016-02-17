# Utilities
Instruments for various tasks

## Tfs Project Clone
Use this utility to clone a project from one project to another (in the same collection). After you build the project just run the exe with the following parameters (in the same order, not named)

1. Access token - you can see how to get one here : http://roadtoalm.com/2015/07/22/using-personal-access-tokens-to-access-visual-studio-online/ 
2. Build definition Id to clone. The easiest way is to select it in the browser and you can see the ID in the URL
3.  Source Project Name
4. Destination Projet Name

For example you can run: *TfsProjectClone.exe InvalidAccessToken!@# 123 Project1 PRoject2*

NOTE : do not have high expectations, the tool is written in a hurry and does the job - it will not validate parameters, provide help or anything. You have access to the code (it is simple) so that you should be able to deal with any issues yourself.
