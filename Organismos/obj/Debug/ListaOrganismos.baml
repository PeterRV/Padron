   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5      E AOrganismos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Organismos.ConvertersOrganismos.Converters 5          Organismos.ListaOrganismos   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      9	converter#clr-namespace:Organismos.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullEfilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        
�������  � 	Resources  5      + %Organismos.Converters.CiudadConverter   
ciudadConv1 +Organismos.Converters.DistribucionConverter  	distrConv��%:   &	        &	        5   
   6$     5   
   6*   5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� $��	10,18,0,0q�6   $
��Left=�5      $	��Top=�5      $��Buscar:��5      $
��Bold"�5         UIControls.SearchTextBox  5   
   -   5        $	��256��5   #   $��	85,18,0,0q�5   #   $
��Left=�5   #   $	��Top=�5    #      	LabelText$* $Buscar por organismo o ubicación...��5!   #    �� TextWrapping$
 Wrap=�5#   #   �� 5$   
   -   5         ��Name$ 
LblTotales��5$      $��	0,10,20,0q�5%      $��Right=�5&      $	��Top=�5'      $��Label��5(      $��14(�5)      $
��Bold"�5*      /  )BolapanControl.ItemsFilter.FilterDataGrid  5,   
   -   5          Name$ GOrganismos��5,       $��1��5-       $��Stretch=�5.       $��Stretch=�5/       &   System.Windows.Controls.DataGrid   AutoGenerateColumns .     EnableRowVirtualization . $��14(�52          
IsReadOnly . ��54       �� 	   Columns	 56      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6%      Header$ 	Organismo��5:   %   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 59   %   �� *OrganismoDesc+5:   %     5;      $	
 120 6%   $
 Tipo��5=   %    5<   %   �� *TipoOrganismoStr+5=   %     5>      $	
 120 6%   $ Distribución��5@   %    5?   %   �� *Distribucion+5@   %     5A      $	
 150 6%   $ Ciudad��5D   %    5B   %   �� *Ciudad+ �� 	Converter# [  5D   %   5F      5G      5H      