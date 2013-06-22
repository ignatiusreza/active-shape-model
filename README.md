Active Shape Model Research
===========================

This is the code for my college final project back in 2007.
It is an implementation of [active shape models (ASMs)](http://personalpages.manchester.ac.uk/staff/timothy.f.cootes/tfc_publications.html)
developed by [Tim Cootes](http://personalpages.manchester.ac.uk/staff/timothy.f.cootes/) and
Chris Taylor.

When compiled it resulted in two different executable,
one for building and analyzing the training set, it will later spit out a .pdm, which then can be
use by the ASM executable to recognized given images.

Source of images can be given by loading pictures, videos, or streamed from the webcam.

At almost every stage of training, analyzing, and recognizing, the process can be configured, so
the executable can be used as a tools to measure what kind of configuration gives the best result
for each different case or object intended to be recognized.
