#DeepSpace

Please cite our work -- here is the ICMJE Standard Citation:

...and a link to the DOI:

Awesome Logo

You can make a free DOI with zenodo

Website (if applicable)

Intro statement

Develop a VR environment for the ‘physical’ assembly of neural networks. Users of the tool will grab neural networks in the virtual and connect them to define the architecture, then run backprop and monitor training inside the VR.
Why should we solve it?

What is ?

Overview Diagram

How to use

Software Workflow Diagram

File structure diagram

Define paths, variable names, etc

Installation options:

We provide two options for installing : Docker or directly from Github.

Docker

The Docker image contains as well as a webserver and FTP server in case you want to deploy the FTP server. It does also contain a web server for testing the main website (but should only be used for debug purposes).

docker pull ncbihackathons/<this software> command to pull the image from the DockerHub
docker run ncbihackathons/<this software> Run the docker image from the master shell script
Edit the configuration files as below
Installing from Github

git clone https://github.com/NCBI-Hackathons/<this software>.git
Edit the configuration files as below
sh server/<this software>.sh to test
Add cron job as required (to execute .sh script)
Configuration

Examples here

Testing

We tested four different tools with . They can be found in server/tools/ .

Additional Functionality

DockerFile

comes with a Dockerfile which can be used to build the Docker image.

git clone https://github.com/NCBI-Hackathons/<this software>.git
cd server
docker build --rm -t <this software>/<this software> .
docker run -t -i <this software>/<this software>
Website

There is also a Docker image for hosting the main website. This should only be used for debug purposes.

git clone https://github.com/NCBI-Hackathons/<this software>.git
cd Website
docker build --rm -t <this software>/website .
docker run -t -i <this software>/website
