   M S B A M L   `   `   `  ����K  GcapaPresentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:capaPresentacion.PaginascapaPresentacion.Paginas  5      .    (capaPresentacion.Paginas.EstudianteLibro   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:capaPresentacion.Paginas     5      -   5          N� Title$  EstudianteLibro��5	      .��5      (� .��5   
   � 
�������$	��800��6"   $	��450��6.   .+�5      �� -   5         ��Name$ tb_buscarEstudiant��5      $
��Left=�62   $��26��6M   $��266,117,0,0q�6Y    �� TextWrapping$
 Wrap=�6n   $	��Top=�6�   $	��329��6�   6�   �� 5      $��Codigo de Estudiante:��6   $
��Left=�64   $��26��6O   $��128,117,0,0q�6[   $	��Top=�6p   $	��126��6�   �� 5      $��Nombre��6   $
��Left=�6%   $��26��6@   $��488,216,0,0q�6L   $	��Top=�6a   $��82��6y   �� 5      $��Codigo: ��6   $
��Left=�6'   $��26��6B   $��488,174,0,0q�6N   $	��Top=�6c   $��61��6{   �� 5      $��Apellido Materno��6   $
��Left=�6/   $��26��6J   $��488,305,0,0q�6V   $	��Top=�6k   $	��108��6�   �� 5      -   5        $ 	tb_nombre��5      $
��Left=�6)   $��26��6D   $��602,216,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��186��6�   {�.  6�   �� 5      -   5        $ tb_codigoEstudi��5      $
��Left=�6/   $��26��6J   $��602,174,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $	��186��6�    J� RenderTransformOrigin$ 0.546,-0.346&�6�   {�.  6�   �� 5      -   5        $ 	tb_ApellP��5      $
��Left=�6)   $��26��6D   $��602,259,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��186��6�   {�.  6�   �� 5      -   5         ��Name$ btn_selectLibr��5         ButtonStyle#���   5      $��Seleccionar Libros��5      $
��Left=�5      $��548,400,0,10q�5      $	��186��5      {�.  5   2   �� 5        
LabelStyle#���  6   $��238,35,223,379q�69   $*��$Buscar Estudiante para Prestar Libro��6Q   �� 5      -   5        $ 
btn_Buscar��5   ;   #���   6   $��Buscar��6O   $
��Left=�6`   $��26��6{   $��615,117,0,0q�6�   $	��Top=�6�   $��93��6�   6�   �� 5      $��Apellido Paterno��6   $
��Left=�6/   $��26��6J   $��488,259,0,0q�6V   $	��Top=�6k   $	��119��6�   �� 5       -   5        $ 	tb_ApellM��5       $
��Left=�6)   $��26��6D   $��602,305,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��186��6�   {�.  6�   &   System.Windows.Controls.DataGrid  5!      -	   5          Name$ dg_estudiantes��5!      $
��Left=�6G   $��27,171,0,10q�6b   $
��Auto��6w      
IsReadOnly . ��6/   �� 6�   �� 5"      -
   5        $ tb_telefono��5"      $
��Left=�6+   $��26��6F   $��602,348,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��186��6�   {�.  6�   �� 5#      -   5         ��Name$ Telefono��5#      $��Telefono��6&   $
��Left=�69   $��26��6T   $��488,348,0,0q�6`   $	��Top=�6u   $	��108��6�   5&      5(      5)      