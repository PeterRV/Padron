   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5      	 Obras&    Obras.Padron.CatalogoObrasPadron   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullEfilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        
�������.��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 
LblTotales��5      $��0,0,20,0q�5      $��Right=�5      $	��Top=�5      $��Label��5      $��14(�5      $
��Bold"�5      �� 5   
   $��10,5,0,0q�6   $
��Left=�5      $	��Top=�5      $��Buscar:��5      $
��Bold"�5         UIControls.SearchTextBox  5   
   -   5        $��0��5   #   $	��250��5   #   $��85,5,0,0q�5    #   $
��Left=�5!   #   $	��Top=�5"   #      	LabelText$, &Buscar por título, material o ISBN...��5#   #   5$   #   /  )BolapanControl.ItemsFilter.FilterDataGrid  5&   
   -   5          Name$ GObras��5&       $��1��5'       $��Stretch=�5(       $��Stretch=�5)       &   System.Windows.Controls.DataGrid   AutoGenerateColumns .     EnableRowVirtualization .    
IsReadOnly . ��5-       ��    Columns 50      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   	   Header$	 Título��54   %   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 53   %   �� *Titulo+54   %     55      $	 100 6%   $	 Núm. Material��57   %   
 56   %   �� *NumMaterial+57   %     58      $	 100 6%   $	 Año Publicación��5:   %   
 59   %   �� *AnioPublicacion+5:   %     5;      $	 150 6%   $
	 ISBN��5=   %   
 5<   %   �� *Isbn+5=   %     5>      $ 90 6%   $	 Tiraje��5@   %   
 5?   %   �� *Tiraje+5@   %   5B      5C      5D      