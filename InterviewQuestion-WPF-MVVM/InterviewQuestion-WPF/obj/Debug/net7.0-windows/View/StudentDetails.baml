   M S B A M L   `   `   `  ����P  LInterviewQuestion-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:InterviewQuestion_WPF.ViewInterviewQuestion_WPF.View  5      Q-clr-namespace:InterviewQuestion_WPF.ViewModelInterviewQuestion_WPF.ViewModel  5      /    )InterviewQuestion_WPF.View.StudentDetails   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:InterviewQuestion_WPF.View     5      C	ViewModel-clr-namespace:InterviewQuestion_WPF.ViewModel     5        � 	Resources  5
         ColumnTitleText �� 
TargetType �� Property �� Value  ColumnValueText��%X  &	        &	 �     �� 5   
   " ��6(   .�5      ��  � ��
 �����5      �� 5       � �� �#6CACE45      �� 5       � ��$ 24(�5      5      �� 5   
   " ��6(   .�5      ��  � ��
 �   �5      �� 5       � ��
 �����5      �� 5       � ��$ 24(�5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5       �� 5!      �� 5"       � ColumnDefinitions 5$   
   �� 5%      $	��15* �6   �� 5&      $	��85* �6   .+�5(   
   �� -   5         ��Name$ cmbStudents��5(      $��0��5)      $��2��5*       �� SelectedIndex$ 0��5+      $��20(�6    �� DisplayMemberPath$ DisplayName��5,      ��5+   +   �� *
Students+	 �� SelectedValue	 5-      �� *	Student+5.      �� 5/   
   $��1��6   $��0��50      #��[  51      .��65   	User ID6>   �� 52   
   $��1��6   $��1��53      #��[ 54      ��55      �� *Student.UserId+61   �� 57   
   $��2��6   $��0��58      #��[  59      .��65   
First Name6A   �� 5:   
   $��2��6   $��1��5;      #��[ 5<      ��5=      �� *Student.FirstName+68   �� 5?   
   $��3��6   $��0��5@      #��[  5A      .��65   	Last Name6@   �� 5B   
   $��3��6   $��1��5C      #��[ 5D      ��5E      �� *Student.LastName+67   �� 5G   
   $��4��6   $��0��5H      #��[  5I      .��65   Display Name6C   �� 5J   
   $��4��6   $��1��5K      #��[ 5L      ��5M      �� *Student.DisplayName+6:   5N      5O      