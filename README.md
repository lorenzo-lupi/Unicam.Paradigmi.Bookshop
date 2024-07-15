Progetto Libreria N01
Descrizione del Progetto

Il progetto riguarda la gestione di una libreria con autenticazione e accesso controllato tramite token JWT. Di seguito sono riportate le istruzioni e le informazioni necessarie per avviare e utilizzare il sistema.
Struttura del Progetto
  db-dump: Questa cartella contiene il dump del database enterprise, scritto in SQL (MySQL).

Dettagli della Tabella Users

All'interno della tabella Users del database enterprise, è già presente un record utilizzabile per l'autenticazione. I dettagli sono i seguenti:

  Email: email@unicam.it
  Password: password

Autenticazione e Creazione del Token

La creazione del token avviene tramite l'API Token/create, la quale restituisce un token JWT. Questo token è necessario per accedere a tutte le altre API del sistema, ad eccezione delle seguenti:

  Users/create
  Token/create

Regole di Accesso

  Le API Users/create e Token/create sono accessibili senza autenticazione.
  Tutte le altre API richiedono che l'utente sia autenticato tramite un token JWT valido.
