   M S B A M L   `   `   `  ����O  KRandomImageGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:RandomImageGeneratorRandomImageGenerator  5   	   %    RandomImageGenerator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:RandomImageGenerator     5   	   -   5          � Title$  
MainWindow��5   	   $	��800��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   (� $��1��6    (� Stretch$ Uniform=�6   $��Center=�61   $��5 5 5 15q�6N   .��5      �� -   5        $��Image��5      $	��640��6!   $	��480��6-   5      � 5      -   5        $��settingsGridfirst��5      $��2��6	    � ColumnDefinitions 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5      � $��0��6
   $��0��6   $��5 0 0 0q�6'    5      �� 5       $
��Auto �6   �� 5!      $
��Auto �6   .+�5#      �� $��0��6   $��Center=�6    Number of points (0-100000):6Z   �� 5$      -   5        $��pointsNumberTextBox��5$   Y   $��1��6   $
��Left=�6   $��22��69    �� TextWrapping$
 Wrap=�6E   $
��1000��6t    �� TextAlignment$ Right=�6�   $��Center=�6�   $��80��6�   5%      � 5&      $��1��6
   $��0��6   $��5 0 0 0q�6'    5'      �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   .+�5+      �� $��0��6   $��Center=�6    Dots diameter (0.5-10)[px]:6X   �� 5,      -   5        $��diameterTextBox��5,   Y   $��1��6   $
��Left=�6   $��22��69   $
 Wrap=�6E   $��Center=�6p   $��1��6�   $ Right=�6�   $��60��6�   5-      � 5.      $��2��6
   $��0��6   $��5 0 0 0q�6'    5/      �� 50      $
��Auto �6   �� 51      $
��Auto �6   .+�53      �� $��0��6   $��Center=�6    Background color:6N   �� 54      -   5        $��backgroundCombobox��54      $��1��6*   $
��Left=�6:   $��	10 0 10 0q�6U   $	��Top=�6i   $	��120��6�   55      �� 57      -   5        $��randomizeDiamaters��57      $��0��6(   $��1��68   $��5 5 0 0 q�6E   .��6W   Randomize dots diameters6q   �� 58      -   5        $��verticalMirror��58      $��1��6$   $��1��64   $��5 5 0 0 q�6A   .��6S   Mirror vertical6d   �� 59      -	   5        $��horizontalMirror��59      $��2��6&   $��1��66   $��5 5 0 0 q�6C   .��6U   Mirror Horizontal6h   5;      � 5<      -
   5        $��settingsGrid��5<      $��3��6	    5=      �� 5>      $��* �6   �� 5?      $
��Auto �6   �� 5@      $
��Auto �6   .+�5B      �� -   5        $��generateButton��5B      $��1��6   $��	10 0 10 0q�62   $��30��6E   .��6n   Generate and draw5D      �� 5E      -   5        $��exportButton��5E      $��2��6   $��	10 0 10 0q�60   $��30��6C   .��6k   Save canvas5G      5H      5J      5K      