# Bierliste
## Problem
Bei uns im Unternehmen gibt es Liste auf der Festgehalten wird wer, wem, wie viele Bier schuldet.

Diese Liste galt es zu digitalisieren.

## Technologien
### Backend
- Windows	Azure Cloud
- Asp.net Core
- Stellt REST Service zur verfügung
- Speichert die Liste

### Frontend
- Angular 2
- Spricht REST Service an

## Umsetzung

### Backend
Es wurde über das Visual Studio eine App Service API auf der Azure Cloud angelegt und ein Asp.net Core API Project deployed.

Ist für das Speichern und auslieferung der Bierliste zuständig.

Das REST Service bietet folgende Endpoints:
- GetList - GET - Gesamte Bierliste wird zürückgegeben ()
- Incement -PUT - Bierschuld um 1 erhöhen (Person 1, Person 2)
- Decrement - PUT - Bierschuld um 1 vermindern (Person 1, Person 2)
- Add - POST - Hinzufügen von einer neuen Person (neue Person)
- Delete - DELETE - Entfernen einer Person (Person)

### Frontend
- Es kann im Frontend eine neu Person zu der Bierliste hinzugefügt werden!
- Es kann eine Person entfernt werden wenn niemand mehr bei ihr Schulden hat und die Person auch bei niemanden mehr Schulden hat.
- Es kann die Bierliste angezeigt werden (Zu jeder Person wie viel ihr alle anderen Personen schulden)
- Bei jedem Personen-Paar können die Schulden erhöht und verringert werden.
