   M S B A M L   `   `   `  ???? F  Bappswindows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:appswindows.user_controleappswindows.user_controle  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf )    #appswindows.user_controle.dashboard   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49an jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9local'clr-namespace:appswindows.user_controle     b	 ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 c
 _DevExpress.Xpf.Charts.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts 
 >Wpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf 
 -   $??572.86??$??1016.366??.???   ? ColumnDefinitions  ?? $
??570* ??? $	??35* ??? $
??170* ??? $	??35* ??? $
??199* ? ? RowDefinitions ?? $	??40* ??? $	??29* ??? $	??57* ??? $	??34* ??? $
??413* ?.+?? $??10,35,198,15q?$??4??.+??? 
???????$??0,10,0,0q?._?  LiveCharts.Wpf.PieChart  -     Name$ prchart1??$??0,44,0,0q?? $??372,35,0,15q?$??4??$??5?? ?? $
??164* ??? $
??191* ?  ?? $
??317* ??? $
??327* ?.+?&   System.Windows.Controls.DataGrid  -     Name$ 	data_vent??$??Disabled=?   AutoGenerateColumns .  $??9,10,0,0q?
???????$??2??$??2??   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Date ??   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding ?? *
date_vente+	 ?? Mode$	 OneWay=?  $ quantity??$	 100  ?? *qentity_vente+$	 OneWay=?  $ produit??$	 100  ?? *nom_produit+$	 OneWay=?  $ client??$	 105  ?? *
nom_client+$	 OneWay=?  $ emplyee??$	 100  ?? *	login_emp+$	 OneWay=?  $ 
prix vente??$	 120  ?? *
prix_vente+$	 OneWay=?? $??0,10,198,375q?$??Right=?$	??362??$??5??.+??? 
???????._?? -   .+??? $??152,10,10,150q?$??20(?$
??Bold"?$??Microsoft YaHei UI)?
 ?? TextAlignment$
 Center=? J? Opacity$	 0.4Q???Z? ?? $?Emplyee???? ?? ??  ?? CornerRadius$ 80??$??10,10,216,53q????? -   	emplyeess?? ?? ImageSource$K EC:/Users/Z-TECH/source/repos/appswindows/appswindows/icon/profile.png?? j? Stretch$ UniformToFill=??? -    ??Name$ nmbrprod??$??112233??$??36,155,257,17q?$
??Bold"?$??Microsoft YaHei UI)?$	 0.4Q?$??11(?' 	 !MaterialDesignThemes.Wpf.PackIcon     Kind$ ShoppingCart=?$??31??$??	5,155,0,0q????	#FFFF962D J? RenderTransformOrigin$ 0.698,0.615&?$??16??$	 0.4Q??? -   $ catigo??$??	catigorie??$??254,151,15,17q?$??Microsoft YaHei UI)?$	 0.4Q?$??14(??? -   $
 xemp??$??112233??$??146,154,139,18q?$
??Bold"?$??Microsoft YaHei UI)?$	 0.4Q?$??11(?  $
 Cash=?$??31??$??115,151,0,0q????	#FF2C4B1A$ 0.698,0.615&?$??20??$	 0.4Q?  $ 
Typewriter=?$??31??$??223,155,0,0q????	#FF0046FF$ 0.698,0.615&?$??16??$	 0.4Q??? -	   $ id??$??198,55,0,105q?$
??Bold"?$??Microsoft YaHei UI)?$	 0.4Q?$??Id??$??14(??? -
   $
 name??$??198,88,0,78q?$??14(?$
??Bold"?$??Microsoft YaHei UI)?$	 0.4Q??? $
?Name???? ?? ?? ??   $ 	UserBadge=?$??31??$??
162,50,0,0q????	#FF131313$ 0.698,0.615&?$??27??$	 0.4Q?  $
 User=?$??31??$??
162,82,0,0q????	#FF131313$ 0.698,0.615&?$??33??$	 0.4Q?? $??
0,10,0,375q?$??Right=?$	??636??
???????$??5??$??5??.+??? $??19,10,447,110q????	#FF24CBC3$	??170??$??68??._?? .+??? -   $	 qte??$??30(?$??	10,0,0,10q?
???????$??48??$??Bottom=?$	 0.7Q?$??--??$
??Left=?$	??150??  $ Package=?$??61??$??	109,0,0,0q?
???????$ 0.698,0.615&?$??68??$	 0.6Q??? $??226,10,240,110q????	#FFFFC758$	??170??$??68??._?? .+?  $
 cart=?$??61??$??	109,0,0,0q?
???????$ 0.698,0.615&?$??68??$	 0.6Q??? -   $
 prod??$??30(?$??	10,0,0,10q?
???????$??48??$??Bottom=?$	 0.7Q?$??--??$
??Left=?$	??150???? $??435,10,31,110q????	#FFF06A51$	??170??$??68??._?? .+?  $ users=?$??61??$??	109,0,0,0q?
???????$ 0.698,0.615&?$??68??$	 0.6Q??? -   $ client??$??30(?$??	10,0,0,10q?
???????$??48??$??Bottom=?$	 0.7Q?$??--??$
??Left=?$	??150???? $??19,100,447,20q????	#FF2196F3$	??170??$??68??._?? .+?  $ UserCardDetails=?$??51??$??	109,0,0,0q?
???????$ 0.698,0.615&?$??68??$	 0.6Q??? -   $ 
emplyeesss??$??30(?$??	10,0,0,10q?
???????$??48??$??Bottom=?$	 0.7Q?$??--??$
??Left=?$	??150???? $??226,100,240,20q????	#FFA77EF0$	??170??$??68??._?? .+?  $ Elevator=?$??61??$??	109,0,0,0q?
???????$ 0.698,0.615&?$??68??$	 0.6Q??? -   $ forniseurss??$??30(?$??	10,0,0,10q?
???????$??48??$??Bottom=?$	 0.7Q?$??--??$
??Left=?$	??150???? $??435,100,31,20q????	#FF6774C9$	??170??$??68??._?? .+?  $
 Cash=?$??61??$??	109,0,0,0q?
???????$ 0.698,0.615&?$??68??$	 0.6Q??? -   $ 	salestout??$??29(?$??	10,0,0,10q?
???????$??48??$??Bottom=?$	 0.7Q?$??--??$
??Left=?$??99??