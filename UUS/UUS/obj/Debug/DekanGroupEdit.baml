   M S B A M L   `   `   `  ����>  :UUS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UUSUUS  5          UUS.DekanGroupEdit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:UUS     5      -   5          N� Title$  DekanGroupEdit��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��50* �6   �� 5      $	��50* �6    � RowDefinitions 5   
   �� 5      $	��28* �6   �� 5      $	��36* �6   �� 5      $	��49* �6   �� 5      $
��291* �6   �� 5      $	��46* �6   .+�5   
   �� $%��Список студентов��6   $��Arial)�6,   $��20(�6?   $��2��6M   $��Center=�6a   $��318,0q�6~   $	��164��6�   �� 5   
   $��Группы: ��6   $��Arial)�6$   $��20(�67   $��1��6E   $��0��6R   $
��Left=�6b   $��5,5,0,5q�6}   $��78��6�   �� 5   
   -   5        $��GroupNmbLabel��5      $��Arial)�6%   $��20(�68   $	��100��6F   $��30��6R   $��Center=�6^   $��1��6y   $��0��6�   $
��Left=�6�   $��88,5,0,5q�6�   �� 5   
   $"��Специальность: ��6   $��Arial)�6+   $��20(�6>   $��2��6L   $��0��6Y   $
��Left=�6i   $��5,5,0,5q�6�   $	��155��6�   �� 5   
   -   5        $��SpecialityNameLabel��5      $��Arial)�6+   $��20(�6>   $��2��6L   $��2��6Y   $	��630��6m   $��30��6y   $	��Top=�6�   $
��Left=�6�   $��	160,5,0,5q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��Student_Data��5      $��Stretch=�6'   $��Stretch=�6E   $��2��6b   $��3��6v      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6Y      
FontFamily$ Arial)�6f   	   FontSize$	 14Q�6y   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *StudentSurname+6y     5      $ Имя��6%   $
 auto 6R   $ Arial)�6_   $	 14Q�6r   
 62   �� *StudentName+6r     5       $ Отчество��6%   $
 auto 6]   $ Arial)�6j   $	 14Q�6}   
 67   �� *StudentPatronymic+6}   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $
 auto 6)      CellTemplate 5"      �� 5#      .R�5$      �� $��
BtnStudent��6M   -   5        $=��7Открыть информацию о студенте��5$   %   $��Arial)�6_   $��14(�6�   6�   5%      5'      5)      �� 5*   
   -   5        $��BackBtn��5*      $��
Назад��6    $��Arial)�60   $��18(�6C   $��4��6Q   $��1��6^   $	��100��6�   $��30��6�   $��Right=�6�   $��5q�6�   �� 5+   
   $G��AСформировать отчет об успеваемости��6   $��Arial)�6>   $��14(�6Q   $
��Left=�6_   $��	10,11,0,0q�6z   $��4��6�   $	��Top=�6�   $	��261��6�   $��30��6�   5,      5-      