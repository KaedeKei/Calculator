   M S B A M L   `   `   `  ����E  ACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Calculator
Calculator  5   	       Calculator.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Calculator     5   	     � Title$  
MainWindow��5   	   $	��378��6   $	��308��6)    � 	Resources 5
         Style_ButtonDefault �� 
TargetType �� Property �� Value  Style_TextBoxHystory  Style_TextBoxInput��%g  &	        &	     &	 ,    �� 5   
   " ��6,   .�5      ��  � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$
 Auto��6'   �� 5       � ��$
 Auto��6&   �� 5       � ��$ 5q�6'   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6-   .�5      ��  �@��
IsReadOnly$
 True��6+   �� 5       �@��TextAlignment$ Right=�6.   �� 5       � ��$
 Auto��6'   �� 5       � ��$
 Auto��6&   �� 5       � ��$ 
5, 1, 5, 1q�6'   �� 5       � ��$ 9(�6)   5      �� 5   
   " ��6+   .�5      ��  �@��
IsReadOnly$
 True��6+   �� 5       �@��TextAlignment$ Right=�6.   �� 5        � ��$
 Auto��6'   �� 5!       � ��$
 Auto��6&   �� 5"       � ��$ 5q�6'   �� 5#       � ��$ 24(�6)   5$      5&      .��5'      �  � ColumnDefinitions 5(   
   �� 5)      $��* �6   �� 5*      $��* �6   �� 5+      $��* �6   �� 5,      $��* �6    � RowDefinitions 5.   
   �� 5/      $��* �6   �� 50      $��2* �6   �� 51      $��2* �6   �� 52      $��2* �6   �� 53      $��2* �6   �� 54      $��2* �6   �� 55      $��2* �6   .+�58   
   �� -   5         ��Name$ textBoxHystory��58      $��0��59      $��0��6   $��4��5:      #��[ 5;      �� 5=   
   -   5        $ textBoxInput��5=      $��1��5>      $��0��6   $��4��5?      #��[ 5@      �� 5B   
   -   5         ��Name$ buttonCE��5B      $��2��5C      $��0��6   $��CE��5D      #��[  5E      5F      �� 5H   
   -   5        $ buttonC��5H      $��2��5I      $��1��6   $��C��5J      #��[  5K      5L      �� 5N   
   -   5        $ 	buttonDel��5N      $��2��5O      $��2��6   $��<��5P      #��[  5Q      5R      �� 5T   
   -   5        $ 	buttonDiv��5T      $��2��5U      $��3��6   $��/��5V      #��[  5W      5X      �� 5Z   
   -   5        $ button7��5Z      $��3��5[      $��0��6   $��7��5\      #��[  5]      5^      �� 5`   
   -   5        $ button8��5`      $��3��5a      $��1��6   $��8��5b      #��[  5c      5d      �� 5f   
   -	   5        $ button9��5f      $��3��5g      $��2��6   $��9��5h      #��[  5i      5j      �� 5l   
   -
   5        $ 
buttonMult��5l      $��3��5m      $��3��6   $��*��5n      #��[  5o      5p      �� 5r   
   -   5        $ button4��5r      $��4��5s      $��0��6   $��4��5t      #��[  5u      5v      �� 5x   
   -   5        $ button5��5x      $��4��5y      $��1��6   $��5��5z      #��[  5{      5|      �� 5~   
   -   5        $ button6��5~      $��4��5      $��2��6   $��6��5�      #��[  5�      5�      �� 5�   
   -   5        $ 	buttonSub��5�      $��4��5�      $��3��6   $��-��5�      #��[  5�      5�      �� 5�   
   -   5        $ button1��5�      $��5��5�      $��0��6   $��1��5�      #��[  5�      5�      �� 5�   
   -   5        $ button2��5�      $��5��5�      $��1��6   $��2��5�      #��[  5�      5�      �� 5�   
   -   5        $ button3��5�      $��5��5�      $��2��6   $��3��5�      #��[  5�      5�      �� 5�   
   -   5        $ 	buttonSum��5�      $��5��5�      $��3��6   $��+��5�      #��[  5�      5�      �� 5�   
   -   5        $ 	buttonDot��5�      $��6��5�      $��0��6   $��.��5�      #��[  5�      5�      �� 5�   
   -   5        $ button0��5�      $��6��5�      $��1��6   $��0��5�      #��[  5�      5�      �� 5�   
   -   5        $ buttonResult��5�      $��6��5�      $��2��6   $��2��6.   $��=��5�      #��[  5�      5�      5�      5�      