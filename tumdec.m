clc;
close all;
clear all;
I = imread('E:\im2.jpg');
%change the image location as per your choice

figure, imshow(I), title('Original Image');
I1 = rgb2gray(I);
H1 = histeq(I1);
figure, imshow(H1), title('Histogram equalized image');

H = fspecial('gaussian',20, 40);
K = imfilter(H1,H, 'replicate');
figure, imshow(K), title('gaussian filtered image');

se = strel('disk',5);
M2 = imopen(K,se); 
%M2 = imopen(H1,se);
figure, imshow(M2), title('After Imopen');
se = strel('disk',12);

imc = imclearborder(M2);
figure, imshow(imc), title('after clear border');
BW = imextendedmin(imc,40);
figure, imshow(BW);
C = edge(BW,'sobel');
figure, imshow(C), title('Final Output');