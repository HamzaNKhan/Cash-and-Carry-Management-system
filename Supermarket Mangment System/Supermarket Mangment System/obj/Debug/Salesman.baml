   M S B A M L   `   `   `  ����V  RSupermarket Mangment System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Supermarket_Mangment_SystemSupermarket_Mangment_System  5      *    $Supermarket_Mangment_System.Salesman   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:Supermarket_Mangment_System     5        N� WindowHeight$	  700Q�5       N� WindowWidth$	 750Q�6    N� Title$ Salesman��5	       � 	Resources 5
       	  label �� 
TargetType �� Property �� Value  textbox  btn �� 
TargetType �� CornerRadius	 �� Padding  grid&   System.Windows.Controls.DataGrid��%U  &	        &	 �     &	 g    &	     �� 5   
   " ��6   .�5      ��  � ��$ 	10,5,10,5q�6'   �� 5       � �� �#03d3fc6+   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6    .�5      ��  � ��$ 	10,5,10,5q�6'   �� 5       � ��$	 200��6&   �� 5       � �� �#0883a16+   �� 5       � �� �#bdf2ff6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 	30,30,0,0q�6'   �� 5       � ��
 �����6+   �� 5       � ��$	 150��6&   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 25��6'   �� 5       � �� 5      �� 5       " ��6&   .R�5!      �� $ 15��6!   ���#03d3fc$��1q�6I   $	 2q�6]   ._�5"      �� $��Center=�6/   $��Center=�6L   5#      5$      5&      5'      �� 5)   
   "  6   .�5*      ��  � �� �#ffecdb6+   �� 5+       � �� �#03d3fc6,   �� 5,       � ��$ 5q�60   �� 5-       � �� �#fc9a776+   �� 5.       � ��$	 200��6'   �� 5/       � ��$	 450��6&   50      51      .��54      �� 
 �� Orientation$
 Vertical=�6   $	��Top=�6(   $	��700��6@   $	��750��6M   .+�56   
   �� $b��\E:\HAMZA\5th Semester\Visual Programming\Final Project\Supermarket Mangment System\eagle.png��6   $	��150��6w   $	��150��6�   �� 58   
   $��Salesman Panel��6   $��24(�6)   $��
sans-serif)�67   ���#03d3fc$��Center=�6d   $��	ExtraBold"�6�   $��40��6�   $	��192��6�   �� 59   
   -   5        $��25��59      $��15��6   $��Right=�6(   $��0,0,30,0q�6D   ���#5aed97.��5:      �� $c��]E:\HAMZA\5th Semester\Visual Programming\Final Project\Supermarket Mangment System\logout.png��6   5;      �� 5<   
   $
 
Horizontal=�6   $��0,20,0,0q�6.   .+�5=      �� $��Search��6   #��[  6&   �� 5>      -   5         ��Name$ search��5>      $	��200��6&   #��[ 62   6S   �� 5?      -   5        ���#5aed97$��25��5?   +   $��25��67   .��5@      �� .+�5A      �� $c��]E:\HAMZA\5th Semester\Visual Programming\Final Project\Supermarket Mangment System\search.png��6   $��18��6�   $��38��6�   5B      5C      5D      �� 5F   
   $
 
Horizontal=�6   .+�5G      �� -   5         ��Name$
 list��5G      $��See List��6#   $��60��66   #��[ 6A   6^   �� 5H      -   5        $ expired��5H      $��Expired Products��6&   $	��120��6A   #��[ 6M   6j   5I      �� 5K   
   -   5        $��Generate Invoice��5K      #��[ 6,   $	��300��6I   6U     5M   
   -   5          Name$ datagrid��5M         
IsReadOnly . $��0,30,0,0q�68      SelectionMode$ Single=�6J   #��[ 6a   5P      5Q      