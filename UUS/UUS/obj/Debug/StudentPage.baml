   M S B A M L   `   `   `  ����>  :UUS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UUSUUS  5          UUS.StudentPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:UUS     5        N� Title$  StudentPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��94* �6   �� 5      $
��683* �6   �� 5      $
��223* �6   .+�5   
   �� $��Stretch=�6   $��5q�63   $��Stretch=�6>   $��3��6Z   .@�5      �� $6��0Информация о пользователе��6   .��5      � ���	#FFE5E5E5.+�5      �� $��Фамилия: ��6    $
��Left=�61   $��	10,31,0,0q�6L   $	��Top=�6_   $��Arial)�6w   $��14(�6�   $��0��6�   �� 5      $��Имя: ��6    $
��Left=�6-   $��	10,62,0,0q�6H   $	��Top=�6[   $��Arial)�6s   $��14(�6�   $��0��6�   �� 5      $��Отчество: ��6    $
��Left=�62   $��	10,93,0,0q�6M   $	��Top=�6`   $��Arial)�6x   $��14(�6�   �� 5      $��Email: ��6    $
��Left=�6/   $��
10,124,0,0q�6J   $	��Top=�6^   $��0��6v   $��Arial)�6�   $��14(�6�   �� 5      $��Телефон: ��6    $
��Left=�61   $��
10,155,0,0q�6L   $	��Top=�6`   $��0��6x   $��Arial)�6�   $��14(�6�   �� 5      -   5         ��Name$ ID_Label��5      $�� ��6.   $
��Left=�69   $��	134,0,0,0q�6T   $	��Top=�6g   $��14(�6   $��1��6�   $��Arial)�6�   �� 5      -   5        $ Surname_Label��5      $�� ��63   $
��Left=�6>   $��
134,31,0,0q�6Y   $	��Top=�6m   $��Arial)�6�   $��1��6�   $��14(�6�    J� RenderTransformOrigin$ 	2.9,0.538&�6�   �� 5      -   5        $ 
Name_Label��5      $�� ��60   $
��Left=�6;   $��
134,62,0,0q�6V   $	��Top=�6j   $��Arial)�6�   $��1��6�   $��14(�6�   �� 5      -   5        $ Patronymic_Label��5      $�� ��66   $
��Left=�6A   $��
134,93,0,0q�6\   $	��Top=�6p   $��Arial)�6�   $��1��6�   $��14(�6�   �� 5      -   5        $ Email_Label��5      $�� ��61   $
��Left=�6<   $��134,124,0,0q�6W   $	��Top=�6l   $��Arial)�6�   $��14(�6�   $��1��6�   �� 5      -   5        $ Phone_Label��5      $�� ��61   $
��Left=�6<   $��134,150,0,0q�6W   $	��Top=�6l   $��Arial)�6�   $��14(�6�   $��1��6�   5      5       �� 5!      $��Журнал��6   .��5"      � ���	#FFE5E5E5.+�5#      &   System.Windows.Controls.DataGrid  -   5          Name$ Journal_Data��5#      $
��Left=�65   $	��371��6P   $	��Top=�6]   $	��766��6u      AutoGenerateColumns .     
IsReadOnly .    Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО студента��61   	   
FontFamily$	 Arial)�6g   
   FontSize$
 14Q�6z      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *FIO_Student+6�     5&      $) #Наименование курса��61   $	 Arial)�6l   $
 14Q�6   $
 Auto 6�    6M   �� *
CourceName+6�     5'      $ Семестр��61   $	 Arial)�6^   $
 14Q�6q   $
 Auto 6    6B   �� *	Semestr+6     5(      $ Дата��61   $	 Arial)�6X   $
 14Q�6k   $
 Auto 6y    6?   �� *Date+6y     5)      $' !ФИО преподавателя��61   $	 Arial)�6l   $
 14Q�6   $
 Auto 6�    6L   �� *FIO_Teacher+6�   5+      5,      5-      5.      5/      50      