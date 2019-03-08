# FlowCalc

Berechnung der Fördermenge von Pool-Pumpen in Abhängigkeit des Systemdrucks.

## Installation
Das Programm erfordert keine Installation. Es kann nach dem kompilieren direkt gestartet werden, beziehungsweise kann eine im [Release-Feed](https://github.com/100prznt/FlowCalc/releases) veröffentlichte Version herunter geladen und gestartet werden.

## Bedienung
1. Über die Schaltfläche `Lade Pumpendefinition...` muss eine gültige Pumpen-Definitionsdatei geladen werden. Unter [PumpDefinitions](https://github.com/100prznt/FlowCalc/tree/master/PumpDefinitions) finden sich einige dieser Dateien.
Siehe auch Abschnitt [Pumpendefinition](#pumpendefinition) hier im Readme.
2. Eingabe des Systemdrucks, im Feld _Systemdruck [bar]_. Dies ist der Druck nach der Pumpe, beziehungsweise vor dem Filter, Eingabe hat in __bar__ zu erfolgen.
3. Die Berechnung der Fördermenge wird mit der Schaltfläche `Berechne Fördermenge` gestartet und direkt angezeigt.

## Anwendung
### Hauptfenster
![Hauptfenster](docs/FlowCalc_Screen.png)

### Anzeige - Pumpenkennlinien
![Anzeige - Pumpenkennlinien](docs/FlowCalc_PumpPerformanceCurve_Screen.png)

### Anzeige - Arbeitspunkt auf Pumpenkennlinie
![Anzeige - Arbeitspunkt auf Pumpenkennlinie](docs/FlowCalc_PowerPoint_Screen.png)

## Pumpendefinition
Das Programm benötigt zur Berechnung eine Pumpenkennlinie. Diese muss in Form einer Pumpendefinitionsdatei angegeben werden. 

### Vorhandene Pumpendefinitionsdateien
* Speck - Badu Picco II
* Speck - Badu Magic II/6
* Speck - Badu Magic II/11
* Aqua TechniX - AquaPlus 6
* Aqua TechniX - AquaPlus 8
* Aqua TechniX - AquaPlus 11
* _Unbekannt_ - SPS-75

### Pumpendefinitionsdatei erstellen
siehe [/PumpDefinitionEditor](/PumpDefinitionEditor)

TODO...

### Beispiel
```xml
<?xml version="1.0" encoding="utf-8"?>
<Pump xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Modell>AquaPlus 6</Modell>
  <Manufacturer>Aqua TechniX GmbH</Manufacturer>
  <PowerOutput>0.25</PowerOutput>
  <NominalQ>6</NominalQ>
  <NominalH>8</NominalH>
  <Author>Elias Ruemmler</Author>
  <AuthorEmail>pool@100prznt.de</AuthorEmail>
  <PerformanceCurve>
    <Ipp>
      <H>10.9</H>
      <Q>0</Q>
    </Ipp>
    <Ipp>
      <H>10.6</H>
      <Q>1</Q>
    </Ipp>
    <!-- Beliebige Anzahl weiterer Ipp-Nodes hier -->
  </PerformanceCurve>
</Pump>
```

## Releases
Dieses Projekt wird auf der Continuous Integration Plattform [AppVeyor](https://www.appveyor.com/) kompiliert und im [Release-Feed](https://github.com/100prznt/FlowCalc/releases) veröffentlicht.

[![AppVeyor Build](https://img.shields.io/appveyor/ci/100prznt/flowcalc.svg)](https://ci.appveyor.com/project/100prznt/flowcalc)  
[![AppVeyor Tests](https://img.shields.io/appveyor/tests/100prznt/flowcalc/master.svg)](https://ci.appveyor.com/project/100prznt/flowcalc/build/tests)

[![GitHub Release](https://img.shields.io/github/release/100prznt/FlowCalc.svg)](https://github.com/100prznt/FlowCalc/releases/latest)  
[![GitHub (Pre-)Release](https://img.shields.io/github/release/100prznt/FlowCalc/all.svg)](https://github.com/100prznt/FlowCalc/releases) (Pre-)Release


## Mitwirken

Ich bin auf der Suche nach weiteren Entwicklern für dieses Projekt. Ideeen und Verbesserungen können aus einem Fork per Pull-Request eingereicht werden.

[![GitHub Contributors](https://img.shields.io/github/contributors/100prznt/FlowCalc.svg)](https://github.com/100prznt/FlowCalc/graphs/contributors)


## Credits

* **Elias Ruemmler** - *Initial work* - [rmmlr](https://github.com/rmmlr)

Unter [Contributors](https://github.com/100prznt/FlowCalc/contributors) können weitere Projekt-Unterstützer eingesehen werden.

### Open Source Project Credits

* [csmatio](https://sourceforge.net/projects/csmatio/) .NET Library for Matlab MAT-files 
* [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) Json.NET is a popular high-performance JSON framework for .NET
* [ZedGraph](https://www.nuget.org/packages/ZedGraph/) ZedGraph is a class library, user control, and web control for .net, written in C#, for drawing 2D Line, Bar, and Pie Charts.

## Lizenz

Dieses Projekt (FlowCalc) ist lizenziert unter der [MIT Lizenz](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form").  
Weitere Details unter [LICENSE.txt](https://github.com/100prznt/FlowCalc/blob/master/LICENSE.txt).

[![license](https://img.shields.io/github/license/100prznt/FlowCalc.svg)](https://github.com/100prznt/FlowCalc/blob/master/LICENSE.txt) 
