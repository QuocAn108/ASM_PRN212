   M S B A M L   `   `   `  ����I  ETourManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TourManagementTourManagement  5   	   (    "TourManagement.ViewTourDestination   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TourManagement     5   	     � Title$  View tour destination��5      $	��600��6#   $
��1000��60    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ CanResizeWithGrip=�6b   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� -   5         ��Name$ SearchTextBox��5      $��0,0,10,0q�6-   $��5q�6?   $��Center=�6K   �� 5      -   5         ��Name$ SearchButton��5      $��1��6+   $��Search��6;   $
��10,5q�6L   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ToursDestinationDataGrid��5      $��1��65   $��	0,0,573,0q�6B      CustomDataGridColumnHeader   ColumnHeaderStyle# [  5        CustomDataGridRow	   RowStyle#	 [ 5        CustomDataGridCell
   	CellStyle#
 [ 69      AutoGenerateColumns$ False��5         CanUserAddRows$ False��6'      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Location ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *
LocationId+  5      $ Tour ID��6%   $	 150 66    6B   �� *TourId+  5      $
 Type��6%   $	 200 63    6?   �� *Type+5!      � 5"   
   $��2��6   $��Right=�6    5#      �� 5$      $
��Auto �6#   �� 5%      $
��Auto �6#   �� 5&      $
��Auto �6#   �� 5'      $
��Auto �6#   .+�5)      �� -   5        $ UpdateButton��5)      $��0��6+   $��Update��6;   $
��10,5q�6L   $��0,0,10,0q�6[   �� 5*      -   5        $ DeleteButton��5*      $��1��6+   $��Delete��6;   $
��10,5q�6L   $��0,0,10,0q�6[   �� 5+      -   5        $ CreateButton��5+      $��2��6+   $��Create��6;   $
��10,5q�6L   $��0,0,10,0q�6[   �� 5,      -   5        $ 
QuitButton��5,      $��3��6)   $
��Quit��69   $
��10,5q�6H   6W   5-      5.      5/      