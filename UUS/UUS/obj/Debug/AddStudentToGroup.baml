   M S B A M L   `   `   `  ����>  :UUS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UUSUUS  5          UUS.AddStudentToGroup   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:UUS     5        N� Title$  AddStudentToGroup��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��40* �6   �� 5      $	��33* �6   �� 5      $	��44* �6   �� 5      $	��47* �6   �� 5      $	��40* �6   �� 5      $	��36* �6   �� 5      $
��209* �6   �� 5      $	��51* �6    � ColumnDefinitions 5   
   �� 5      $	��17* �6   �� 5      $	��17* �6   .+�5   
   �� $7��1Добавить студента в группу��6   $��18(�66   $��Arial)�6D   $��2��6W   $��Center=�6k   �� 5   
   $��ФИО Студента: ��6   $��Arial)�6*   $��18(�6=   $��0��6K   $��Right=�6[   $��Center=�6w   $��2��6�   $��0,5,5,5q�6�   $��22��6�   $
��Auto��6�   �� 5   
   -   5        $��FIOStudentsList��5       �� DisplayMemberPath$	 Fio��6*   $��1��6B   $��2��6R   $��18(�6_   $��Arial)�6m   $��Stretch=�6�   $��5q�6�   �� 5   
   $��Группа:��6   $��Arial)�6#   $��18(�66   $��0��6D   $��3��6T   $��Center=�6a   $��Right=�6|   $��0,5,5,5q�6�   $��22��6�   $
��Auto��6�   �� 5   
   -   5        $��
GroupsList��5      $��Arial)�6&   $��18(�69   $��2��6G   $��3��6W   $	��200��6d   $
��Left=�6p   $��5q�6�   �� 5    
   -   5        $��BackBtn��5    !   $��
Назад��6   $��7��60   $��1��6=   $	��100��6M   $��25��6Y   $��Bottom=�6e   $��Right=�6�   $��	0,0,115,5q�6�   $��Arial)�6�   $��18(�6�   �� 5!   
   -   5        $��AddBtn��5!   $   $��Добавить��6   $��7��62   $��1��6?   $	��100��6O   $��25��6[   $��Bottom=�6g   $��Right=�6�   $��0,0,5,5q�6�   $��Arial)�6�   $��18(�6�   5"      5#      