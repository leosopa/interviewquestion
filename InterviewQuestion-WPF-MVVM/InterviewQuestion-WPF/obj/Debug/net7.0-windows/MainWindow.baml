   M S B A M L   `   `   `  ����P  LInterviewQuestion-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:InterviewQuestion_WPFInterviewQuestion_WPF  5   	   G(clr-namespace:InterviewQuestion_WPF.ViewInterviewQuestion_WPF.View  5   	   Q-clr-namespace:InterviewQuestion_WPF.ViewModelInterviewQuestion_WPF.ViewModel  5   	   &     InterviewQuestion_WPF.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:InterviewQuestion_WPF     5   	   =controls(clr-namespace:InterviewQuestion_WPF.View     5   	   C	viewmodel-clr-namespace:InterviewQuestion_WPF.ViewModel     5   	     � Title$  
MainWindow��5
   	    � 	Resources 5         BooleanToVisibility  GridBackground �� 
TargetType �� Property �� Value  LabelBackground 
 Button��%�  &	        &	      &	 a     &	 �    �� 5   
   6'   �� 5   
   " �6'   .�5      ��  � �� �#0030876+   5      �� 5   
   " ��6(   .�5      ��  � �� �#0030876+   �� 5       � ��
 �����6+   �� 5       � ��$ Lucida Sans)�6+   �� 5       � ��$ 20(�6)   �� 5       � ��$ 10q�6(   �� 5       � ��$
 Left=�6;   �� 5       � ��$ Stretch=�64   5      �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 40��6'   �� 5       � ��$ Lucida Sans)�6+   �� 5       � ��$ DemiBold"�6+   �� 5       � ��$ 20(�6)   �� 5       � ��$ Center=�64   5       5!      .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   �� 5&      $��45 �6   .+�5(   
   �� $��Stretch=�6   $��Stretch=�5)      $��0��6-   .+�5*      �� #��[ 5+      $��72(�5,      .��6   WPF Interview Quiz62   �� 5-      #��[ 6   $��20(�5.      $��Stretch=�5/      .��6.   Select a Student to detail:6K   51      ,   &InterviewQuestion_WPF.View.SaveStudent  52   
   $��1��6   y�53      �� *IsSaveVisible+ �� 	Converter# [  /   )InterviewQuestion_WPF.View.StudentDetails  54   
   $��1��6"   y�55      �� *IsDetailVisible+# [  � 56   
   $��2��6   $��Stretch=�57      $��Stretch=�58      #��[ 59      y�5:      �� *IsCommandsVisible+# [   � ColumnDefinitions 5;      �� 5<      $��* �6#   �� 5=      $��* �6#   �� 5>      $��* �6#   .+�5A      �� -   5         ��Name$ btnAdd��5A      $��0��6%   $	��Add��66   #��[ 5C      ��5B      �� *
AddCommand+5C      �� 5D      -   5        $ 	btnUpdate��5D      $��1��6(   $��Update��69   #��[ 5F      ��5E      �� *UpdateCommand+5F      �� 5G      -   5        $ 	btnDelete��5G      $��2��6(   $��Delete��69   #��[ 5I      ��5H      �� *DeleteCommand+5I      5K      � 5M   
   $��2��6   $��Stretch=�5N      $��Stretch=�5O      #��[ 5P      y�5Q      �� *IsSaveVisible+# [   5R      �� 5S      $	��15* �6+   �� 5T      $	��10* �6+   �� 5U      $	��75* �6+   .+�5W      �� -   5        $ btnSave��5W      $��1��5X      $
��Save��6.   $
��Left=�5Y      #��[ 5[      ��5Z      �� *SaveCommand+5[      �� 5\      -   5        $ 	btnCancel��5\      $��2��5]      $��Cancel��6"   $
��Left=�5^      #��[ 5`      5a      5b      5c      