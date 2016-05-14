#! /bin/sh
 
echo 'Downloading from http://netstorage.unity3d.com/unity/fdbb5133b820/MacEditorInstaller/Unity-5.3.4f1.pkg: '
curl -o Unity.pkg http://netstorage.unity3d.com/unity/fdbb5133b820/MacEditorInstaller/Unity-5.3.4f1.pkg
 
echo 'Installing Unity.pkg'
sudo installer -dumplog -package Unity.pkg -target /