   M S B A M L   `   `   `  ����O  KNumericUpDownControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:NumericUpDownControl;assembly=NumericUpDownControlNumericUpDownControl  5   	   	 Obras   Obras.ObrasWin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Tcontrol@clr-namespace:NumericUpDownControl;assembly=NumericUpDownControl     5   	   -   5          � Title$  Obras��5   	   $	��661��5   	   $	��396��5   	    � Icon$ Resources/rocket.ico��5   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��35 �6   .+�5   
   � -   5        $��PanelCentral��5      .+�5      �� $��	24,13,0,0q�6   $
��Left=�5      $	��Top=�5      $��Título:��5      �� 5      -   5         ��Name$ 	TxtTitulo��5      $��96��5      $��
25,44,25,0q�5      $��Stretch=�5      $	��Top=�5       �� TextWrapping$
 Wrap=�5      ��5      �� *Titulo+5      �� 5      $��
25,153,0,0q�6   $
��Left=�5       $	��Top=�5!      $��Núm. de material:��5"      �� 5#      -   5        $ TxtNumMaterial��5#      $	��140��5$      $��23��5%      $��
24,183,0,0q�5&      $
��Left=�5'      $	��Top=�5(      $
 Wrap=�5.      ��5,      �� *NumMaterial+ �� Mode$ TwoWay=�5.      �� 5/      $��
25,272,0,0q�6   $
��Left=�50      $	��Top=�51      $��Presentación:��52      �� 53      -   5         ��Name$ CbxPresentacion��53      $	��176��54      $��
24,298,0,0q�55      $
��Left=�56      $	��Top=�57      	 �� DisplayMemberPath$	 Descripcion��58      
 �� SelectedValuePath$
 
IdElemento��5:      ��59      �� 5:      �� 5;      $��192,153,0,0q�6   $
��Left=�5<      $	��Top=�5=      $��Núm. de volúmenes:��5>      %   NumericUpDownControl.NumericBox  5?      -   5          Name$ TxtNumVolumen��5?   !   $	��120��5@   !   $��23��5A   !   $��192,183,0,0q�5B   !   $
��Left=�5C   !   $	��Top=�5D   !      Maximum$ 15��5E   !      Minimum$ 1��5F   !      Value 5G   !   �� *	NumLibros+$ TwoWay=��� 5I      -   5        $ TxtIsbn��5I      $	��140��5J      $��23��5K      $��347,183,0,0q�5L      $
��Left=�5M      $	��Top=�5N      $
 Wrap=�5S      ��5R      �� *Isbn+5S      �� 5T      $��347,153,0,0q�6   $
��Left=�5U      $	��Top=�5V      $��ISBN:��5W      �� 5X      $��273,272,0,0q�6   $
��Left=�5Y      $	��Top=�5Z      $��Tipo de obra:��5[      �� 5\      -   5        $ CbxTipoObra��5\      $	��176��5]      $��273,298,0,0q�5^      $
��Left=�5_      $	��Top=�5`      $	 Descripcion��5a      $
 
IdElemento��5c      ��5b      �� 5c      �� 5e      $��505,153,0,0q�6   $
��Left=�5f      $	��Top=�5g      $��Año publicación:��5h        5j      -	   5        $ TxtYear��5j   !   $	��125��5k   !   $��23��5l   !   $��505,183,0,0q�5m   !   $
��Left=�5n   !   $	��Top=�5o   !   $
 3000��5p   !   $
 1870��5q   !    5r   !   �� *AnioPublicacion+$ TwoWay=��� 5t      $��29��6   $��20��5u      $��390,159,0,0q�5v      $
��Left=�5w      $	��Top=�5x      $��Resources/question_64.png��5y       � ToolTip$c ]El formato de ISBN para 10 digitos es XXX-XXX-XXX-XXX-X para 13 dígitos es 978-XXX-XXX-XXX-X��5z      �� 5{      $��
25,214,0,0q�6   $
��Left=�5|      $	��Top=�5}      $��Tiraje:��5~        5      -
   5        $ TxtYear_Copy��5   !   $	��139��5�   !   $��23��5�   !   $��
25,244,0,0q�5�   !   $
��Left=�5�   !   $	��Top=�5�   !   $
 1000��5�   !    5�   !   �� *Tiraje+$ TwoWay=�5�      �� 5�   
   -   5         ��Name$ BtnSalir��5�      $��1��5�      $��75��5�      $��0,7,15,0q�5�      $��Right=�5�      $	��Top=�5�      $��Salir��5�       �� IsCancel . 5�      �� 5�   
   -   5        $ 
BtnGuardar��5�      $��1��5�      $��75��5�      $��0,7,95,0q�5�      $��Right=�5�      $	��Top=�5�      $��Guardar��5�       �� 	IsDefault . 5�      5�      5�      