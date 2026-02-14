# Questionnaire API

Web API sviluppata in .NET per esporre un questionario tecnico tramite endpoint REST.
Il progetto è strutturato con approccio DDD e Onion architecture (Domain, Application, Infrastructure, Api) e include gestione centralizzata delle eccezioni e test unitari.

---

## Tecnologie utilizzate

* .NET 8
* ASP.NET Core Web API
* xUnit
* NSubstitute
* AutoFixture
* FluentAssertions

---

## Struttura del progetto

* **Domain**: entità e value objects
* **Application**: servizi, DTO e logica applicativa
* **Infrastructure**: repository e accesso ai dati (JSON)
* **Api**: controller, middleware e configurazione
* **Tests**: test unitari

---

## Come avviare l'applicazione

```bash
dotnet restore
dotnet run --project PhotoSi.Questionnaire.Api
```

Swagger sarà disponibile all'avvio, ad esempio:

```
http://localhost:<port>/swagger
```

---

## Avvio con Docker

Costruire l’immagine dalla root folder del progetto:

```bash
docker build -t photosi-questionnaire-api .
```

Avviare il container:

```bash
docker run --rm -p 8080:8080 photosi-questionnaire-api
```

L’applicazione sarà disponibile su:

```
http://localhost:8080/swagger
```

## Esempi di chiamata API

Recuperare tutte le domande:

```bash
curl http://localhost:8080/api/questionnaire
```

Recuperare una domanda per id:

```bash
curl http://localhost:8080/api/questionnaire/1
```

Ricercare nelle domande:

```bash
curl http://localhost:8080/api/questionnaire/search?term=dotnet
```


---

## Endpoint principali

| Metodo | Endpoint                        | Descrizione                    |
| ------ | ------------------------------- | ------------------------------ |
| GET    | /api/questionnaire              | Restituisce tutte le domande   |
| GET    | /api/questionnaire/{id}         | Restituisce una domanda per id |
| GET    | /api/questionnaire/search?term= | Ricerca nelle domande          |

---

## Eseguire i test

```bash
dotnet test
```

---

## Scelte progettuali

* Architettura a layer per separare le responsabilità
* Repository JSON per semplicità e isolamento dell'infrastruttura
* Middleware globale per la gestione delle eccezioni
* Test unitari su service, factory e controller

---

## Note

Il progetto è stato sviluppato come esercizio tecnico per dimostrarvi:

* organizzazione del codice
* testabilità
* gestione degli errori in una Web API .NET
* che so rendere informale la formalit� di un questionario 😀

## Autore

- Filippo Palliani
