   M S B A M L   `   `   `  ����  Funcionarios&     Funcionarios.Resources.QueRecibe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  	QueRecibe��5   	   $	��550��5   	   $	��386��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ LstTipoObras��5      $��10,45,10,50q�5      $��Stretch=�5      $��Stretch=�5       �� DisplayMemberPath$ Descripcion��5       �� SelectedValuePath$ 
IdElemento��5      ��5      �� 5      �� 5   
   $��	10,14,0,0q�6   $
��Left=�5      $	��Top=�5      $��Obras que recibe:��5      $
��Bold"�5      �� 5   
   -   5        $ LstAcuerdos��5      $��1��5       $��10,45,10,50q�5!      $��Stretch=�5"      $��Stretch=�5#      $ Descripcion��5$      $ 
IdElemento��5&      ��5%      �� 5&      �� 5)   
   -   5         ��Name$ 
BtnGuardar��5)      $��1��5*      $��75��5+      $��
0,326,10,0q�5,      $��Right=�5-      $	��Top=�5.      $��Guardar��50      �� 51   
   -   5        $ BtnCancelar��51      $��1��52      $��75��53      $��
0,326,93,0q�54      $��Right=�55      $	��Top=�56      $��Cancelar��58      �� 59   
   $��1��6   $��	10,14,0,0q�5:      $
��Left=�5;      $	��Top=�5<      $&�� Acuerdo en el que esta incluido:��5=      $
��Bold"�5>      5@      5A      