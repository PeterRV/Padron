   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5   	   G CFuncionarios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW;clr-namespace:Funcionarios.Converters;assembly=FuncionariosFuncionarios.Converters 5   	    
Organismos(   "Organismos.SelecccionaFuncionarios   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   C
UIControls,clr-namespace:UIControls;assembly=UIControls     5   	   Q	converter;clr-namespace:Funcionarios.Converters;assembly=Funcionarios     5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullEfilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   	   -   5          � Title$  Selecccionar Funcionarios��5   	   $	��600��5   	   $	��300��5	   	    � 	Resources 5      -  'Funcionarios.Converters.TituloConverter   
tituloConv��%   &	          5   
   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��45 �6   .+�5   
      UIControls.SearchTextBox  -   5        $	��382��5   #   $��	75,15,0,0q�5   #   $
��Left=�5   #   $	��Top=�5   #      	LabelText$&  Buscar por nombre y apellidos...��5   #   5   #   �� 5   
   $��	10,10,0,5q�6   $
��Left=�5      $	��Top=�5      $��Buscar:��5       $��14(�5!      $��Black"�5"      /  )BolapanControl.ItemsFilter.FilterDataGrid  5$   
   -   5          Name$ 
GTitulares��5$       $��1��5%       $��Stretch=�5&       $��Stretch=�5'       &   System.Windows.Controls.DataGrid   AutoGenerateColumns .     EnableRowVirtualization . $��14(�5*          
IsReadOnly . ��5,       ��    Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 80 6%   
   Header$
 Título��53   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 51   %   �� *
IdTitulo+ �� 	Converter# [  53   %     54      $		 .7* 6%   $
 Nombre��56   %    55   %   �� *Nombre+56   %     57      $		 .8* 6%   $
 	Apellidos��59   %    58   %   �� *	Apellidos+59   %   5;      �� 5<   
   -   5         ��Name$ BtnSalir��5<      $��2��5=      $��75��5>      $��
507,14,0,0q�5?      $
��Left=�5@      $	��Top=�5A      $��Salir��5C      �� 5D   
   -   5        $ 
BtnGuardar��5D      $��2��5E      $��75��5F      $��
427,14,0,0q�5G      $
��Left=�5H      $	��Top=�5I      $��Agregar��5K      5O      5P      