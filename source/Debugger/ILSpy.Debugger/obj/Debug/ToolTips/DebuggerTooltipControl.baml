   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5      R NILSpy.Debugger.Plugin, Version=0.1.0.208, Culture=neutral, PublicKeyToken=nullY1clr-namespace:ICSharpCode.ILSpy.Debugger.Tooltips#ICSharpCode.ILSpy.Debugger.Tooltips 5      Y1clr-namespace:ICSharpCode.ILSpy.Debugger.Tooltips#ICSharpCode.ILSpy.Debugger.Tooltips 5	      @  :ICSharpCode.ILSpy.Debugger.Tooltips.DebuggerTooltipControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      [aeroJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     5      G	debugging1clr-namespace:ICSharpCode.ILSpy.Debugger.Tooltips     5      KlocalControls1clr-namespace:ICSharpCode.ILSpy.Debugger.Tooltips     5	      
������   � 	Resources  5       �� MergedDictionaries �� Source�� 5       5      �� 5      $ VisualizerPicker.xaml?�5      �� 5      $  PinControlsDictionary.xaml?�5      %    5      .��5      ��  �� Orientation$ Vertical=�5      .+�5      �� -   5        $��btnUp��5      |�.     upButtonStyle#��[  5      $��^��5      5      &   System.Windows.Controls.DataGrid  5      -   5        $��dataGrid��5&      "   VerticalScrollBarVisibility$ Disabled=�5      $   HorizontalScrollBarVisibility$ Disabled=�5         GridLinesVisibility$
 None=�5          	RowHeight$ 18Q�5!      $	��202��5"         SelectionMode$ Single=�5#      	   SelectionUnit$	 FullRow=�5$      
   AutoGenerateColumns
 .     CanUserAddRows .     HeadersVisibility$
 None=�5)      
�������$��1q�5+      ��5%      �� ��5,      �� 5.       �� 
StartPoint$ 0,-0.03&�5/       �� EndPoint$	 0,1&�50      .��51      �  � Color$ White��52      � 53      $ 	#FFFAFCFE��54       � Offset$ 0.983Q�55      � 56      $ 	#FFECF7FC��57      $
 0.07Q�58      � 59      $ 	#FFEEF7FA��5:      $ 0.436Q�5;      5<         RowStyle 5>      �� 5?       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  5@      .�5A      ��  �� Property � �� �� Value
 ���� 5C       �� Triggers 5D      P� 5E       P� Property �@J�IsMouseOver P� Value . . �5H   	   ��  � �� �	#FFE2F6FE5J   	   5K   	   5M         	CellStyle 5O      �� 5P      *  $System.Windows.Controls.DataGridCell"  5Q      .�5R      ��  � |� .  5T      �� 5V       � ��$ 0q�5X       5Y      P� 5Z       �@ 
IsSelected . . �5^   	   ��  � ��
 �   �5`   	   �� 5a   	    � �� 5c   	   Z� 5d   	   5f         Columns 5h      4  .System.Windows.Controls.DataGridTemplateColumn  5i         CellTemplate 5k      �� 5l      .R�5m   	   � 
�������.+�5o   
   �� $��Center=�5p   
   .+�5q      d�  d�Name$ btnExpander��5r      -   5          ExpandCollapseToggleStyle#��[ 5s      $��0q�5u      $��0q�5v      5w      5x   
    �� Triggers 5y   	   �� 5z   
    �� Value$ False��5|   
    �� Binding 5{   
   ��  �� Path$ HasChildNodes�.a�5}      ��   �� 
TargetName$  btnExpander��5~       � y�$ 	Collapsed=�5�      5�      5�   	   5�        5�       5�      �� 5�      .R�5�   	   �� ��5�   	   �� *ImageSource+6*   5�   	   5�        5�      ,  &System.Windows.Controls.DataGridColumn!   MinWidth$! 20Q�5�      "   Header$
" Name��5�       5�      �� 5�      .R�5�   	   �� ���	#FFDDDDDD$��0 0 1 0q�5�   	   ._�5�   
   ��   TextBlockStyle#��[ 5�   
   $	��Top=�5�   
   ��5�   
   �� $
 Name�# �� Mode$# OneWay=�5�   $   5�   
   5�   	   5�        5�      $! 20Q�5�      $
" Text��5�       5�      �� 5�      .R�5�   	   �� -   5          	TextStyle#��[ 5�   	   {�5�   	   �� *
CanSetText+��5�   	   �� $
 Text�5�   	   5�        5�       5�      �� 5�      .R�5�   	   d� $��	PinButton��5�   	   -   5        $y�	Collapsed=�5�   	   $��Center=�5�   	     PinTooltipButtonTemplate#��[ 5�   	   $ d� 	IsChecked$ 5�   	   �� *
IsPinned+% � DataContext% 5�   	   �� 5�   	    5�   	   �� 5�   
   $
 True��5�   
    5�   
   �� $ IsMouseOver�& �� RelativeSource& �� ' �� Mode$' FindAncestor=�( �� AncestorType$( DataGridRowL�.a�5�      �� $  	PinButton��5�       � y�$ Visible=�5�      5�      5�   	   5�      5�      �� 5�      -   5        $��btnDown��5�      |�.    downButtonStyle#��[ 5�      $��v��5�      5�      5�      5�      