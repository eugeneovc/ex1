   M S B A M L   `   `   `  ����>  :UUS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UUSUUS  5          UUS.JournalAddScorePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:UUS     5        N� Title$  JournalAddScorePage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��55* �6   �� 5      $	��50* �6   �� 5      $
��365* �6   �� 5      $	��46* �6   .+�5   
   �� $%��Выберите группу: ��6   $��Arial)�6-   $��18(�6@   $
��Left=�6N   $��Bottom=�6i   $��5,5,5,5q�6�   $��0��6�   $��21��6�   $	��152��6�   �� 5   
   -   5        $��GroupBox��5       �� DisplayMemberPath$ groupNMB��6#   $��1��6@   $��Arial)�6M   $��Center=�6`   $��Center=�6�   $	��125��6�   $��25��6�   $
��Left=�6�   $��Bottom=�6�   $��5,5,5,5q�6�   �� 5   
   $!��Выберите курс: ��6   $��Arial)�6+   $��18(�6>   $
��Left=�6L   $��Bottom=�6g   $��	190,5,5,5q�6�   $��0��6�   $��21��6�   $	��152��6�   �� 5   
   -   5        $��	CourceBox��5      $ 
courseName��6$   $��1��6C   $��Arial)�6P   $��Center=�6c   $��Center=�6�   $	��450��6�   $��25��6�   $
��Left=�6�   $��Bottom=�6�   $��	190,5,5,5q�6�   �� 5   
   $%��Введите семестр: ��6   $��Arial)�6-   $��18(�6@   $
��Left=�6N   $��Bottom=�6i   $��	670,5,5,5q�6�   $��0��6�   $��21��6�   $	��160��6�   �� 5   
   -   5        $��
SemestrTxb��5      $��1��6%   $��Arial)�62   $��Center=�6E   $��Center=�6i   $��70��6�   $��25��6�   $
��Left=�6�   $��Bottom=�6�   $��	670,5,5,5q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��Journal_Data��5      $��Stretch=�6'   $��Stretch=�6E      AutoGenerateColumns .     
IsReadOnly . $��2��6�   $��5q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО студента��6%      
FontFamily$ Arial)�6[      FontSize$ 14Q�6n   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6|   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *StudentName+6|     5      $! Название курса��6%   $ Arial)�6\   $ 14Q�6o   $
	 Auto 6}   
 6=   �� *
CourceName+6}     5      $ Семестр��6%   $ Arial)�6R   $ 14Q�6e   $
	 Auto 6s   
 66   �� *	Semestr+6s   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
	 auto 6)      CellTemplate 5      �� 5      .R�5       �� $��EditScoreBtn��6@   -   5        $%��Выставить оценку��5    %   $��Arial)�6m   $��14(�6�   5!      5#      5%      �� 5&   
   -   5        $��BackBtn��5&      $	��100��65   $��30��6A   $��3��6M   $��
Назад��6Z   $��Right=�6j   $��Bottom=�6�   $��0,0,5,5q�6�   �� 5'   
   -   5        $
��ОК��5'      $��Right=�64   $��Bottom=�6P   $��0,0,5,5q�6k   $	��100��6|   $��25��6�   $��1��6�   5(      5)      