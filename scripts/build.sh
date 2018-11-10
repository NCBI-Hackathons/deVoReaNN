#! /bin/sh

project="deVoReaNN"

echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity 
  -batchmode 
  -nographics 
  -silent-crashes 
  -logFile $(pwd)/UHACK/unity.log 
  -projectPath $(pwd)/UHACK 
  -buildWindowsPlayer "$(pwd)/UHACK/Build/windows/$project.exe" 
  -quit

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity 
  -batchmode 
  -nographics 
  -silent-crashes 
  -logFile $(pwd)/UHACK/unity.log 
  -projectPath $(pwd)/UHACK 
  -buildOSXUniversalPlayer "$(pwd)/UHACK/Build/osx/$project.app" 
  -quit

echo "Attempting to build $project for Linux"
/Applications/Unity/Unity.app/Contents/MacOS/Unity 
  -batchmode 
  -nographics 
  -silent-crashes 
  -logFile $(pwd)/UHACK/unity.log 
  -projectPath $(pwd)/UHACK 
  -buildLinuxUniversalPlayer "$(pwd)/UHACK/Build/linux/$project.exe" 
  -quit

echo 'Logs from build'
cat $(pwd)/UHACK/unity.log


echo 'Attempting to zip builds'
zip -r $(pwd)/UHACK/Build/linux.zip $(pwd)/UHACK/Build/linux/
zip -r $(pwd)/UHACK/Build/mac.zip $(pwd)/UHACK/Build/osx/
zip -r $(pwd)/UHACK/Build/windows.zip $(pwd)/UHACK/Build/windows/
