   M S B A M L   `   `   `  ����I  ETourManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TourManagementTourManagement  5   	   #    TourManagement.DetailLocation   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TourManagement     5   	   -   5          � Title$  Detail Location��5      $	��456��6%   $	��840��62    � WindowStartupLocation$ CenterScreen=�6>   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ DetailLocationMode��5      $��Title:��6,   $��0��5      $��0��5      $��2��5      $��20(�5      $
��Bold"�5      $��Center=�5      $��0,0,0,20q�5       $	��800��5!         LabelDetail#��[  5"      �� 5$   
   $��Location ID:��6   $��1��5%      $��0��5&      $��0,5,10,5q�5'      #��[  5(      �� 5)   
   -   5         ��Name$ LocationIDTextBox��5)      $��1��5*      $��1��5+       �� 
IsReadOnly$
 True��5,      $��0,5,0,5q�5-        TextBoxDetail#��[ 5.      �� 50   
   $��Location Name:��6   $��2��51      $��0��52      $��0,5,10,5q�53      #��[  54      �� 55   
   -   5        $ LocationNameTextBox��55      $��2��56      $��1��57      $��0,5,0,5q�58      #��[ 59      �� 5;   
   $��Description:��6   $��3��5<      $��0��5=      $��0,5,10,5q�5>      #��[  5?      �� 5@   
   -   5        $ DescriptionTextBox��5@      $��3��5A      $��1��5B      $	��100��5C       �� AcceptsReturn$
 True��5D       �� TextWrapping$
 Wrap=�5E      "	 �� VerticalScrollBarVisibility$
	 Auto=�5F      $��0,5,0,5q�5G      #��[ 5H      �� 5J   
   $��Region:��6   $��4��5K      $��0��5L      $��0,5,10,5q�5M      #��[  5N      �� 5O   
   -   5        $ RegionTextBox��5O      $��4��5P      $��1��5Q      $��0,5,0,5q�5R      �� 5T   
   $��Type:��6   $��5��5U      $��0��5V      $��0,5,10,5q�5W      #��[  5X      �� 5Y   
   -   5        $ TypeTextBox��5Y      $��5��5Z      $��1��5[      $��0,5,0,5q�5\      #��[ 5]      �� 5_   
   $��6��6   $��2��5`      
 �� Orientation$
 
Horizontal=�5a      $��Center=�5b      $��0,20,0,0q�5c        StackPanelDetail#��[ 5d      .+�5e      �� -   5         ��Name$ 
SaveButton��5e      $
��Save��5f      $	��100��5g      $��0,0,10,0q�5h        ButtonDetail#��[ 5i      67   �� 5j      -	   5        $ 
QuitButton��5j      $
��Quit��5k      $	��100��5l      #��[ 5m      67   5n      5o      5p      