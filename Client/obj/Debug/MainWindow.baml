   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5
      $
��Left=�6   $	��339��6:   $��	10,10,0,0q�6G   $	��Top=�6Z   $	��646��6r      
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+	   ClipboardContentBinding	 6<   Z�   5      $ 	FirstName��6    6,   �� *	FirstName+	 6J   Z�   5      $ 
SecondName��6    6-   �� *
SecondName+	 6L   Z�   5      $ LastName��6    6+   �� *
LastName+	 6H   Z�   5      $ DateOfB��6    6*   �� *	DateOfB+	 6F   Z� 5      �� 5      -   5        
 ��Name$
 btnNEXT��5      $��>��6   $
��Left=�6(   $��420,378,0,0q�6C   $	��Top=�6X   $��22��6p   6{   �� 5      -   5         ��Name$ label1��5   
   $��0��6   $
��Left=�6'   $��383,375,0,0q�6C   $	��Top=�6X    J� RenderTransformOrigin$ 0.173,-0.245&�6p   6�   �� 5      -   5        $��<��5      $
��Left=�6   $��348,378,0,0q�65   $	��Top=�6J   $��19��6b   6m   �� 5      -   5        $
 btnEdit��5      $
��edit��6   $
��Left=�6+   $��
10,363,0,0q�6F   $	��Top=�6Z   $��75��6r   6}   �� 5      -   5        $
 addbtn��5      $��add new��6   $
��Left=�6-   $	��Top=�6H   $��75��6`   $��
10,389,0,0q�6k   6   �� 5      -   5        $
 	deleteBTN��5      $��delete��6   $
��Left=�6/   $	��Top=�6J   $��75��6b   $��
90,378,0,0q�6m   6�   �� 5      -   5        $
 loginBTN��5      $��login��6   $
��Left=�6-   $��605,389,0,0q�6H   $	��Top=�6]   $��75��6u   6�   �� 5      -	   5        $ loginstatus��5   
   $��Вы не в сети.��6   $
��Left=�67   $��605,358,0,0q�6R   $	��Top=�6g   $	��177��6   �� 5      -
   5        $
 	logoutBTN��5      $��logout��6   $
��Left=�6/   $	��Top=�6J   $��75��6b   $��707,389,0,0q�6m   6�   �� 5      -   5        $
 userinfo��5      $��Профиль��6   $
��Left=�6/   $��505,389,0,0q�6J   $	��Top=�6_   $��75��6w   6�   �� 5      -   5         ��Name$ searchFirstName��5      $
��Left=�6%   $��23��6@   $��
662,14,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5      -   5        $ searchSecondName��5      $
��Left=�6&   $��23��6A   $��
662,52,0,0q�6M   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5       -   5        $ searchLastName��5       $
��Left=�6$   $��23��6?   $��
662,91,0,0q�6K   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5!      -   5        $ searchDateOfB��5!      $
��Left=�6#   $��23��6>   $��662,132,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5"      -   5        $
 	SearchBTN��5"      $��search��6   $
��Left=�6/   $��685,170,0,0q�6J   $	��Top=�6_   $��75��6w   6�   �� 5#      -   5        $
 	CanselBTN��5#      $��Cansel��6   $
��Left=�6/   $��685,195,0,0q�6J   $	��Top=�6_   $��75��6w   6�   5%      5&      