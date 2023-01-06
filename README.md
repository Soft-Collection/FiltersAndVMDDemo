[![Filters And VMD Demo](http://img.youtube.com/vi/HISjkKKGieY/0.jpg)](http://www.youtube.com/watch?v=HISjkKKGieY "Filters And VMD Demo")
[![Filters And VMD Demo](http://img.youtube.com/vi/lAA7cDx-NoE/0.jpg)](http://www.youtube.com/watch?v=lAA7cDx-NoE "Filters And VMD Demo")

# Filters And VMD Demo
Filters And VMD Demo demonstrates the entire Video Motion Detection process.
First of all we have to start Live555 Media Server that will stream desired
Video from file on demand. This Video file must be placed in the same folder as
Media Server's executable file. When the Media Server is ready, we need to connect
to it via RTSP protocol using FFMPEG. When connection established, we will get
encoded frames, that will be decoded to RGB frames using FFMPEG. Now we have
RGB frames that may be to large for VMD so we need to resize them.
Resized frames are also RGB frames so we need to convert them to Grayscale frames
in order to apply them to VMD. Since VMD algorithm may be too hard for CPU, we need
to resize it quickly. To accomplish this goal we divide the frame into macroblocks NxN.
In every such macroblock we get pixel at coordinates (0,0) and put it into new resized
Grayscale (VMD Frame). Each VMD Frame we will put into a Buffer, that allows us to maintain
Average VMD Frame of last N VMD Frames. Now we can get Difference Frame.
Each pixel in that frame is the difference between corresponding pixels in Last VMD Frame
and Average VMD Frame. Now, when we have Difference Frame, we need to decide whether the
difference in that frame is significant enough to be considered as change. So now we will build
Tollerance Frame. If the value in the Difference Frame is bigger than Tollerance Value,
the Tollerance Frame corresponding pixel will have the value of 255, or 0 otherwise.
Tollerance Frame may have noise, in order to reduce this noise we will divide the frame
to macroblocks NxN. Each macroblock's pixel will get median value of all the pixels in
this macroblock. Each macroblock will became a pixel of Median Frame.
Now we have all the objects on the frame as spots. We can get only edges of these spots.
It is Border Frame.
We can also apply various Filters (Blur, Shapen, Edge) to VMD Frame. 

![Connection Diagram](Images/Filters%20And%20VMD%20Demo1.png)

![Connection Diagram](Images/Filters%20And%20VMD%20Demo2.png)
