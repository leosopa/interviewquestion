   M S B A M L   `   `   `  ����P  LInterviewQuestion-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:InterviewQuestion_WPFInterviewQuestion_WPF  5   	   &     InterviewQuestion_WPF.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:InterviewQuestion_WPF     5   	   -   5          � Title$  
MainWindow��5   	    � SizeToContent$ WidthAndHeight=�6    � 	Resources 5
         ColumnTitleText �� 
TargetType �� Property �� Value  ColumnValueText��%X  &	        &	 �     �� 5   
   " ��6(   .�5      ��  � ��
 �����5      �� 5       � �� �#6CACE45      �� 5       � ��$ 24(�5      5      �� 5   
   " ��6(   .�5      ��  � ��
 �   �5      �� 5       � ��
 �����5      �� 5       � ��$ 24(�5      5      5      .��5      �� $��Stretch=�6   $��Stretch=�5      .+�5   
   �� $��10q�6   $��Lucida Sans)�5      $��72(�5       ���#003087
�������$��Center=�5#      $��Stretch=�5$      .��6.   WPF Interview Quiz6B   �� 5%   
   -   5         ��Name$ cmbStudents��5%       �� SelectedIndex$ 0��5&      $��20(�6   5'      � 5(   
    � RowDefinitions 5)      �� 5*      �� 5+      �� 5,      �� 5-      	 � ColumnDefinitions	 5/      �� 50      $��* �6#   �� 51      $��2* �6#   .+�53      �� $��0��6   $��0��54      #��[  55      .��6=   	User ID6F   �� 56      -   5        
 ��Name$
 	lblUserId��56      $��0��57      $��1��58      #��[ 59      6?   �� 5;      $��1��6   $��0��5<      #��[  5=      .��6=   
First Name6I   �� 5>      -   5        $
 lblFirstName��5>      $��1��5?      $��1��5@      #��[ 5A      6?   �� 5C      $��2��6   $��0��5D      #��[  5E      .��6=   	Last Name6H   �� 5F      -   5        $
 lblLastName��5F      $��2��5G      $��1��5H      #��[ 5I      6?   �� 5K      $��3��6   $��0��5L      #��[  5M      .��6=   Display Name6K   �� 5N      -   5        $
 lblDisplayName��5N      $��3��5O      $��1��5P      #��[ 5Q      6?   5R      � 5S   
   	 5T      �� 5U      $��* �6#   �� 5V      $��* �6#   �� 5W      $��* �6#   .+�5Y      �� -   5         ��Name$ btnAdd��5Y      $��0��5Z      $	��Add��5[      $��24(�5\      5]      �� 5^      -   5        $ 	btnUpdate��5^      $��1��5_      $��Update��5`      $��24(�5a      ${�False��5b      5c      �� 5d      -	   5        $ 	btnDelete��5d      $��2��5e      $��Delete��5f      $��24(�5g      ${�False��5h      5i      5j      5k      5l      