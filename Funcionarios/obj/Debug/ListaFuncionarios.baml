   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5      G CFuncionarios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Funcionarios.ConvertersFuncionarios.Converters 5      $   Funcionarios.ListaFuncionarios   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      ;	converter%clr-namespace:Funcionarios.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullEfilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        
�������  � 	Resources  5      . (Funcionarios.Converters.FuncionConverter   funcionConv-  'Funcionarios.Converters.TituloConverter  
tituloConv��%:   &	        &	        5   
   6%     5   
   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
      UIControls.SearchTextBox  -   5        $	��382��5   #   $��	75,15,0,0q�5   #   $
��Left=�5   #   $	��Top=�5   #      	LabelText$1 +Buscar por nombre, apellidos u organismo...��5   #    �� TextWrapping$
 Wrap=�5   #   �� 5!   
   -   5         ��Name$ 
LblTotales��5!      $��	0,10,20,0q�5"      $��Right=�5#      $	��Top=�5$      $��Label��5%      $��14(�5&      $
��Bold"�5'      �� 5)   
   $��	10,10,0,5q�6   $
��Left=�5*      $	��Top=�5+      $��Buscar:��5,      $��14(�5-      $��Black"�5.      /  )BolapanControl.ItemsFilter.FilterDataGrid  50   
   -   5          Name$ 
GTitulares��50       $��1��51       $��Stretch=�52       $��Stretch=�53       &   System.Windows.Controls.DataGrid   AutoGenerateColumns .     EnableRowVirtualization . $��14(�56          
IsReadOnly . ��58       �� 	   Columns	 5:      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 80 6%      Header$ Título��5?   %   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5=   %   �� *
IdTitulo+ �� 	Converter# [ 5?   %     5@      $	
 .7* 6%   $ Nombre��5B   %    5A   %   �� *Nombre+5B   %     5C      $	
 .8* 6%   $ 	Apellidos��5E   %    5D   %   �� *	Apellidos+5E   %     5F      $
 * 6%   $ 	Organismo��5H   %    5G   %   �� *OrganismoAdscripcion+5H   %     5I      $	
 120 6%   $ Funcion��5L   %    5J   %   �� *	Funcion+# [  5L   %   5N      5R      5S      