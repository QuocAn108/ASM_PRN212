   M S B A M L   `   `   `  ����I  ETourManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TourManagementTourManagement  5   	   !    TourManagement.DetailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TourManagement     5   	     � Title$  Create Tour��5   	   $	��476��6   $	��940��6*    � WindowStartupLocation$ CenterScreen=�66   .��5	      � $��20q�6    � RowDefinitions 5
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
   �� $��Tour ID:��6   $��0��6#   $��0��60      LabelDetail#��[  6@   �� 5   
   -   5         ��Name$ TourIDTextBox��5      $��0��6)   $��1��66    �� 
IsReadOnly$
 True��6F   $��	22,4,0,15q�6X     TextBoxDetail#��[ 6k   �� 5   
   $��
Tour Name:��6   $��1��6%   $��0��62   $��	0,10,0,58q�6B   #��[  6U   �� 5   
   -   5        $ TourNameTextBox��5      $��1��6+   $��1��68   $��	22,0,0,97q�6H   #��[ 6[   �� 5   
   $��Description:��6   $��1��6'   $��0��64   $��	0,45,0,15q�6D   $��2��6W   #��[  6h   �� 5    
   -   5        $ DescriptionTextBox��5       $��1��6.   $��1��6;   $	��100��6K    �� AcceptsReturn$
 True��6X   $��
22,48,0,10q�6m   $��2��6�   #��[ 6�   �� 5"   
   $��Price:��6   $��3��6!   $��0��6.   #��[  6>   �� 5#   
   -   5        $ PriceTextBox��5#      $��3��6(   $��1��65   $��	22,4,0,14q�6E   �� 5%   
   $��Number of Participants:��6   $��4��62   $��0��6?   $��2��6O   $��0,10,733,10q�6c   #��[  6x   �� 5&   
   -   5        $ ParticipantsTextBox��5&      $��4��6/   $��1��6<   $��	22,4,0,14q�6L   #��[ 6_   �� 5(   
   $��Farm ID:��6   $��5��6#   $��0��60   #��[  6@   �� 5)   
   -   5         ��Name$ FarmIDComboBox��5)      $��5��6+   $��1��68   $��	22,9,0,10q�6H   .@�5*      �� $��Farm 1��6   �� 5+      $��Farm 2��6   �� 5,      $��Farm 3��6   5-      �� 5/   
   $��6��6   $��2��6"     StackPanelDetail#��[ 66   .+�50      �� -   5         ��Name$ 
SaveButton��50      $
��Save��6)     ButtonDetail#��[ 68   �� 51      -   5        $ 
QuitButton��51      $
��Quit��6)   #��[ 68   52      53      54      