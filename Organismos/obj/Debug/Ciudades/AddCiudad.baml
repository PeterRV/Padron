   M S B A M L   `   `   `  ����E  AOrganismos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Organismos.ConvertersOrganismos.Converters  5   	   #    Organismos.Ciudades.AddCiudad   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9	converter#clr-namespace:Organismos.Converters     5   	   -   5          � Title$  Agregar Ciudad��5   	   $	��315��5   	   $	��348��5   	    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5      ,   &Organismos.Converters.TextValConverter   textConv��%   &	          5   
   6%   5      .��5      � .+�5   
   �� $��	27,34,0,0q�6   $
��Left=�5      $	��Top=�5      $��País:��5      �� 5   
   -   5         ��Name$ CbxPais��5      $	��255��5      $��	27,65,0,0q�5      $
��Left=�5      $	��Top=�5       �� DisplayMemberPath$ PaisDesc��5      {�.   �� SelectedValuePath$ IdPais��5      ��5      �� 5      �� 5   
   $��
27,117,0,0q�6   $
��Left=�5      $	��Top=�5      $��Estado:��5       �� 5!   
   -   5        $ 	CbxEstado��5!      $	��255��5"      $��
27,148,0,0q�5#      $
��Left=�5$      $	��Top=�5%      $ 
EstadoDesc��5&      {�.  $ IdEstado��5)      ��5(      �� 5)      �� 5*   
   $��
27,196,0,0q�6   $
��Left=�5+      $	��Top=�5,      $��Ciudad��5-      �� 5.   
   -   5         ��Name$ 	TxtCiudad��5.      $	��255��5/      $��23��50      $��
27,227,0,0q�51      $
��Left=�52      $	��Top=�53       �� TextWrapping$
 Wrap=�57      ��55      �� *
CiudadDesc+	 �� 	Converter#	 [  57      �� 58   
   -   5        
 ��Name$
 BtnSalir��58      $��75��59      $��114,277,0,0q�5:      $
��Left=�5;      $	��Top=�5<      $��Cancelar��5>       �� IsCancel . 5?      �� 5@   
   -   5        $
 
BtnGuardar��5@      $��75��5A      $��207,277,0,0q�5B      $
��Left=�5C      $	��Top=�5D      $��Guardar��5F       �� 	IsDefault . 5G      5I      5J      