   M S B A M L   `   `   `  ????F  Bappswindows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:appswindowsappswindows  5      !    appswindows.UserControluser   5      ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:appswindows     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $??Stretch=?5	      $??Stretch=?5
      $	??619??6C   .??5      ? $??
0,0,0,-282q?6   $
??Left=?6   $
??1152??6:     ? ColumnDefinitions  5   
   ?? 5      $
??183* ?6   ?? 5      $	??18* ?6   ?? 5      $
??170* ?6   ?? 5      $	??18* ?6   ?? 5      $
??210* ?6   ?? 5      $
??396* ?6    ? RowDefinitions 5   
   ?? 5      $??40.793 ?6   ?? 5      $??20.759 ?6   ?? 5      $??47.241 ?6   ?? 5      $??54.128 ?6   ?? 5      $??295.872 ?6   .+?5   
   ?? $??1q?6   $??	6,9,0,-54q?6%   
???????$??6??6K   $??5??6_   $
??Left=?6p   $	??691??6?   ??5      ?? 5      ._?5      ?  5       ?? 5!      $	??303 ?6$   .+?5#      ?? -   5         ??Name$ search??5#      $??545,105,0,166q?6)   $??Search??6@    J? RenderTransformOrigin$ 0.462,0.707&?6Q   $
??Left=?6?   $	??130??6?   ?? 5$      -   5         ??Name$ 
datasearch??5$      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ search??6.   $??0,105,356,166q?6W   $??32??6n   ???	#FF050505$??Right=?6?   $	??150??6?   ?? 5%      -   5         ??Name$ cosearch??5%      $ Search??6-    ?? 
IsEditable .  &  "MaterialDesignFloatingHintComboBox#??[  6g   $??34,0,537,169q?6?   $??40??6?   ???	#FF050505$??Bottom=?6?   .@?5&      ??  ?? 
IsSelected . .??65   Nom emplyee5(      ?? 5)      .??6#   prenom5+      5-      &   System.Windows.Controls.DataGrid  5.      -   5        	  Name$	 dataemp??5.      $??Disabled=?6,   
   AutoGenerateColumns
 .  
???????   GridLinesVisibility$ 
Horizontal=?6?   $??0,153,0,-189q?6?   $
??Left=?68  $	??647??6S     Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ id??6.      Width5  /System.Windows.Controls.DataGridLengthConverter$   6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   ?? *id_emp+ ?? Mode$ OneWay=?4  .System.Windows.Controls.DataGridTemplateColumn  51      $ image??61   $ 80 6A      CellTemplate 52      ?? 53   "   .R?54   &   ?? $??15??6-   $??15??69    ?? CornerRadius$ 20??6D   ??55   *   ?? 56   .    ?? ImageSource 69   ?? *	image_emp+$ OneWay=?58   '   59   #   5;        5<      $	 nom??6.   $	 100 6;    6G   ?? *nom+$ OneWay=?  5=      $ prenom??6-   $	 100 6=    6I   ?? *prenom+$ OneWay=?  5>      $ 	telephone??6-   $	 100 6@    6L   ?? *Ntele+$ OneWay=?  5?      $ modifier??61    5@      ?? 5A   "   .R?5B   &   ?? $??btnView??6-   -   5        $??modifer??5B   <   $??64??6N   $??20??6Y   $??8(?6e   ???	#FF8DD28A??5C   *   ?? 5D   .   5F   '   5G   #   5I        5J      $ 	suppremer??61    5K      ?? 5L   "   .R?5M   &   ?? $??btnsup??6-   -   5        $??	suppremer??5M   ;   $??68??6O   $??20??6Z   $??8(?6f   
???  ??
???  ??6?   5N   #   5P      5R      ?? 5S      $??133,10,0,225q?6   $??0??6/   ???	#FF3689E5$	??170??6V   $??68??6b   $
??Left=?6n   ._?5T      ? $
??0,10q?6    5U      ?? 5V      .+?5X      ?? -   5         ??Name$ countemp??5X   $   $??0,0,0,5q?66   $??30(?6G   
???????$??--??6h    J? Opacity$
 0.51Q?6r   $??43??6?   $??Bottom=?6?   $??Right=?6?   $	??160??6?   '  !MaterialDesignThemes.Wpf.PackIcon  5Y         Kind$
 User=?63   $??	100,0,0,0q?6@   
???????$ 0.698,0.615&?6f   $??70??6?   $??48??6?   $	 0.7Q?6?   $??Bottom=?6?   5Z      5[      ?? 5\      $??318,10,0,225q?6   ???	#FFEA5118$??68??6F   $
??Left=?6R   $	??170??6m   ._?5]      ? $
??0,10q?6   .+?5^      ?? -   5        $ nbrsal??5^   $   $??10,0,0,5q?64   $??30(?6F   
???????$??--??6g   $
 0.51Q?6q   $??43??6?   $??Bottom=?6?     5_      $ ChartAreaspline=?63   $??	100,0,0,0q?6J   
???????$??70??6q   $??48??6|   $	 0.7Q?6?   $??Stretch=?6?   5a      5b      ?? 5c      $??501,10,0,225q?6   $??0??6/   ???	#FF24CBC3$	??170??6V   $??68??6b   $
??Left=?6n   ._?5d      ? $
??0,10q?6   .+?5e      ?? -	   5        $ salee??5e   $   $??10,0,0,0q?63   $??30(?6E   
???????$??--??6f   $
 0.51Q?6p   $??48??6   $??Bottom=?6?     5f      $
 Sale=?63   $??	100,0,0,0q?6?   
???????$ 0.698,0.615&?6e   $??70??6?   $??48??6?   $	 0.7Q?6?   5g      5h      5i      5j      ?? 5k   
   $??1q?6   $
??Left=?6%   $	??508??6@   $??13,10,-5,-54q?6M   $	??Top=?6c   $	??388??6{   
???????$??5??6?   $??5??6?   ??5l      ?? 5m      ._?5o      ? $??0,0,-1,0q?6   .+?5p      ?? -
   5        $??1q?5p      $??Center=?6D   $	??387??6a   $	??506??6m   $	??Top=?6z   ??5q      ?? 5r      ??5t      ?? 5u      ._?5w      ? $
??0,-1q?6     5x      ?? 5y      .+?5{        $ Account=?62   $??25??6B   $??29??6M   $??
23,264,0,0q?6Y   $ 0.492,2.216&?6m   $
 0.48Q?6?   6?     5|      $ TextUser=?62   $
??Auto??6C   $??22??6P   $??21,316,334,0q?6\   $ 0.342,2.474&?6r   $ 0.625Q?6?   $??Stretch=?6?   z?5}      V? 5~   "   .~?5   &   ?? ?? 5?   &   ?? 5?   &    ?? Angle$ 0.466Q?66   T? 5?   &   5?   #   5?        5?      $ 	Telephone=?62   $??25??6D   $??29??6O   $??
23,358,0,0q?6[   $ 0.342,2.474&?6o   $
 0.63Q?6?   ?? 5?      -   5        $ ajouter??5?   !   $	??Add??62   $??286,452,10,22q?6@   6W   ?? 5?      -   5        $ modifier??5?   !   $??Edite??63   $??286,464,10,10q?6C   ???	#FF43A047$y?Hidden=?6?   ?? 5?      -   5        $
 nime??5?   "   $	 nom??61    % !MaterialDesignFloatingHintTextBox#??[ 6W   $??53,250,239,215q?6?   ? 5?      $??	0,0,173,0q?6   .+?5?      ?? $ 80??6%   $??129,0,-60,366q?67   ??5?   "   ?? 5?   &   -   5        
picbox??$, &/appswindows;component/Img/profile.png??5?   A   5?      5?      ?? 5?      -   5        $ addimge??5?   !   $??delete??62   $??236,98,113,356q?6C   $ 0.368,-0.031&?6[   ??5?      ?? 5?   "   ??5?      ?? 5?   "   ??5?      ?? 5?   "   $) #/appswindows;component/Img/plus.png??6-   5?      ?? 5?      -   5        $ usernime??5?   "   $ Nom d'utilisateur??65   #??[ 6i   $??51,163,183,296q?6?   G? 5?      -   5         G?Name$ password??5?   &   $ ******??68    ) %MaterialDesignFloatingHintPasswordBox#??[ 6a   $??248,174,10,296q?6?     5?      $ 	PersonAdd=?62   $??25??6C   $??29??6N   $??
23,181,0,0q?6Z   $ 0.492,2.216&?6n   $
 0.48Q?6?     5?      $	 Key=?62   $??25??6>   $??29??6I   $??218,181,0,0q?6U   $ 0.492,2.216&?6j   $
 0.48Q?6?   ?? 5?      -   5        $ catigo??5?   #   $
 type??63   #??[  6Y   $??53,200,181,246q?6?   .@?5?      ?? .??6+   À plein temps6:   ?? 5?      .??6+   À temps partiel6<   ?? 5?      .??6+   Décontractée69   ?? 5?      .??6+   Durée déterminée6=   ?? 5?      .??6+   Les travailleurs de quarts6G   ?? 5?      .??6+   location à la journée6B   ?? 5?      .??6+   	Probation66   ?? 5?      .??6+   Apprentis et stagiaires6D   5?        5?      $ 
ListStatus=?62   $??25??6D   $??29??6O   $??
23,221,0,0q?6[   $ 0.492,2.216&?6o   $
 0.48Q?6?   ?? 5?      -   5        $ second??5?   "   $ prenom??63   #??[ 6\   $??51,292,183,168q?6?   ?? 5?      -   5        $ id??5?   4   {?.  $ id??6@   $??29??6d   $??51,131,243,346q?6p   $ 0.188,0.412&?6?     5?      $ IdentificationCard=?62   $
??Auto??6L   $??30??6Y   $??22,131,338,0q?6e   $ 0.492,2.216&?6{   $
 0.48Q?6?   $??Stretch=?6?   ?? 5?      -   5        $ 	telephone??5?   "   $ 	telephone??66   #??[ 6b   $??51,338,185,120q?6?   5?      5?      5?      5?      5?      5?      