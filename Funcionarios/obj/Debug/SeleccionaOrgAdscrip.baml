   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5   	    Funcionarios'   !Funcionarios.SeleccionaOrgAdscrip   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   C
UIControls,clr-namespace:UIControls;assembly=UIControls     5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullEfilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   	   -   5          � Title$*  $Selecciona organismo de adscripción��5   	   $	��500��5   	   $	��300��5   	    � Icon$ Resources/rocket.ico��5	   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
      UIControls.SearchTextBox  -   5        $��0��5   #   $	��250��5   #   $��0,0,0,0q�5   #   $
��Left=�5   #   $	��Top=�5   #      	LabelText$ Buscar organismo...��5   #    �� TextWrapping$
 Wrap=�5   #   /  )BolapanControl.ItemsFilter.FilterDataGrid  5   
   -   5          Name$ GOrganismos��5       $��1��5       $��Stretch=�5       $��Stretch=�5       &   System.Windows.Controls.DataGrid   AutoGenerateColumns .     EnableRowVirtualization . 	   
IsReadOnly	 . ��5"       �� 
   Columns
 5$      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ 	Organismo��5(   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5'   %   �� *OrganismoDesc+5(   %   5*      �� 5+   
   -   5         ��Name$ BtnCancelar��5+      $��2��5,      $��75��5-      $��	0,18,10,0q�5.      $��Right=�5/      $	��Top=�50      $��Cancelar��52       �� IsCancel . 53      �� 54   
   -   5        $ 
BtnGuardar��54      $��2��55      $��75��56      $��	0,18,90,0q�57      $��Right=�58      $	��Top=�59      $��Guardar��5;      5<      5=      