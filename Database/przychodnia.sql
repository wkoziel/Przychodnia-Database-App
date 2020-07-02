-- phpMyAdmin SQL Dump
-- version 3.5.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Czas wygenerowania: 03 Lip 2020, 00:10
-- Wersja serwera: 5.5.21-log
-- Wersja PHP: 5.3.20

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Baza danych: `przychodnia`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `lekarz`
--

CREATE TABLE IF NOT EXISTS `lekarz` (
  `ID_lekarza` int(11) NOT NULL AUTO_INCREMENT,
  `ID_poradni` int(11) NOT NULL,
  `Imię` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Nazwisko` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Numer_telefonu` int(13) NOT NULL,
  `Specjalizacja` text COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`ID_lekarza`),
  KEY `ID_poradni` (`ID_poradni`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci AUTO_INCREMENT=7 ;

--
-- Zrzut danych tabeli `lekarz`
--

INSERT INTO `lekarz` (`ID_lekarza`, `ID_poradni`, `Imię`, `Nazwisko`, `Numer_telefonu`, `Specjalizacja`) VALUES
(1, 1, 'Alina ', 'Kowalska', 252971192, 'Alergolog'),
(2, 2, 'Andzej', 'Biały', 866562652, 'Pediatria'),
(3, 3, 'Katarzyna', 'Białko', 953478718, 'Stomatologia'),
(4, 2, 'Janusz', 'Wąs', 252971191, 'Pediatria'),
(5, 1, 'Marzena', 'Skocz', 789708149, 'Alergolog'),
(6, 3, 'Anna', 'Mucha', 289707189, 'Stomatolog');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pacjent`
--

CREATE TABLE IF NOT EXISTS `pacjent` (
  `PESEL` varchar(11) COLLATE utf8_polish_ci NOT NULL,
  `Imię` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Nazwisko` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Płeć` enum('Mężczyzna','Kobieta') COLLATE utf8_polish_ci NOT NULL,
  `Data_urodzenia` date NOT NULL,
  `Wiek` int(3) NOT NULL,
  `Adres` text COLLATE utf8_polish_ci NOT NULL,
  `Numer_kontaktowy` varchar(11) COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`PESEL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `pacjent`
--

INSERT INTO `pacjent` (`PESEL`, `Imię`, `Nazwisko`, `Płeć`, `Data_urodzenia`, `Wiek`, `Adres`, `Numer_kontaktowy`) VALUES
('05310482498', 'Brajan', 'Kozlo', 'Mężczyzna', '2010-09-18', 10, 'Poznań ul. Kupały 9', '295762313'),
('14291345894', 'Wiktor', 'Nowakowski', 'Mężczyzna', '1983-08-15', 37, 'Warszawa ul. Mikołaja z Długolasu 106', '717152680'),
('16232345969', 'Jessica', 'Bartoszkiewicz', 'Kobieta', '2016-03-23', 4, 'Kraków ul. Podbipięty Longinusa 138', '675962730'),
('16232471169', 'Andżela', 'Bartoszkiewicz', 'Kobieta', '2016-03-24', 4, 'Kraków ul. Podbipięty Longinusa 138', '675962730'),
('59050555596', 'Szczepan', 'Majewski', 'Mężczyzna', '1959-05-05', 61, 'Białystok ul. Angielska 102', '698332935'),
('68050758045', 'Bogumiła', 'Wiśniewska', 'Kobieta', '1968-05-07', 52, 'Warszawa ul. Chryzantemy 108', '988884513'),
('75070671795', 'Mariusz', 'Kozłowski', 'Mężczyzna', '1975-10-06', 45, 'Kielce ul. Malinowa 132', '876354082'),
('83081582452', 'Wiktor', 'Nowakowski', 'Mężczyzna', '1983-08-15', 37, 'Warszawa ul. Mikołaja z Długolasu 106', '717152680'),
('84102832862', 'Grażyna ', 'Żarko', 'Kobieta', '1984-10-28', 36, 'Olkusz ul. Nullo 5/19', '158843588'),
('85102760425', 'Kornelia', 'Rutkowska', 'Kobieta', '1985-10-27', 35, 'Łódź ul. Narcyzowa 114', '53090737'),
('90072764465', 'Józefa', 'Borkowska', 'Kobieta', '1990-07-27', 30, 'Poznań ul. Ikara 85', '226916650'),
('91072850905', 'Oliwia', 'Chmielewska', 'Kobieta', '1991-07-28', 29, 'Łódź ul. Husarska 125', '147483647'),
('94112370775', 'Bazyli', 'Kozłowski', 'Mężczyzna', '1994-11-23', 26, 'Kielce ul. Zwierzyniecka 78', '887595549'),
('98042407532', 'Wojtek', 'Nowak', 'Mężczyzna', '1996-03-03', 24, 'Żywiec ul. Miła 9', '553321332');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `poradnia`
--

CREATE TABLE IF NOT EXISTS `poradnia` (
  `ID_poradni` int(3) NOT NULL AUTO_INCREMENT,
  `Nazwa` varchar(30) COLLATE utf8_polish_ci NOT NULL,
  `Rodzaj_poradni` enum('Prywatna','Publiczna') COLLATE utf8_polish_ci NOT NULL,
  `Opis` text COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`ID_poradni`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci AUTO_INCREMENT=4 ;

--
-- Zrzut danych tabeli `poradnia`
--

INSERT INTO `poradnia` (`ID_poradni`, `Nazwa`, `Rodzaj_poradni`, `Opis`) VALUES
(1, 'Poradnia alergologiczna', 'Publiczna', 'Zajmuje się diagnozowaniem i leczeniem różnego rodzaju alergii.\nAlergie: skórne (w postaci atopowego zapalenia skóry, pokrzywka itp.),\nukładu pokarmowego (alergia pokarmowa),\nukładu oddechowego (alergiczny nieżyt nosa),\ninne choroby skóry i tkanki podskórnej.'),
(2, 'Poradnia Pediatryczna', 'Publiczna', 'Sprawuje opiekę zdrowotną nad dziećmi do 18 roku życia.\nW Poradni przyjmowane są zarówno dzieci chore, jak i dzieci zdrowe\nm.in. na badania kontrolne oraz niezbędne badania okresowe,\nbilanse stanu zdrowia dzieci, oraz szczepienia ochronne.'),
(3, 'Poradnia Stomatologiczna', 'Prywatna', 'Prowadzi działalność leczniczą obejmującą:\nleczenie zachowawcze choroby próchnicowej zębów z zastosowaniem nowoczesnych metod i materiałów,\nleczenie zachowawcze wybranych wad rozwojowych twardych tkanek zębów oraz\nchorób twardych tkanek zębów nie próchnicowego pochodzenia z zastosowanie nowoczesnych metod\ni materiałów, leczenie urazów zębów stałych,\nleczenie endodontyczne zębów z zastosowaniem nowoczesnych metod opracowania i\nwypełniania kanałów korzeniowych,\nleczenie powikłań zaistniałych w trakcie leczenia\nendodontycznego oraz powtórne.');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `przydział_lekarzy`
--

CREATE TABLE IF NOT EXISTS `przydział_lekarzy` (
  `ID_lekarza` int(3) NOT NULL,
  `ID_poradni` int(3) NOT NULL,
  KEY `ID_lekarza` (`ID_lekarza`),
  KEY `ID_poradni` (`ID_poradni`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `przydział_lekarzy`
--

INSERT INTO `przydział_lekarzy` (`ID_lekarza`, `ID_poradni`) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 2),
(5, 1),
(6, 3);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `sala`
--

CREATE TABLE IF NOT EXISTS `sala` (
  `Numer_sali` int(3) NOT NULL,
  `ID_poradni` int(3) NOT NULL,
  `Typ_sali` enum('Gabinet','Zabiegowa') COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`Numer_sali`),
  KEY `ID_poradni` (`ID_poradni`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `sala`
--

INSERT INTO `sala` (`Numer_sali`, `ID_poradni`, `Typ_sali`) VALUES
(1, 1, 'Gabinet'),
(2, 1, 'Gabinet'),
(3, 1, 'Zabiegowa'),
(4, 2, 'Gabinet'),
(5, 2, 'Gabinet'),
(6, 2, 'Zabiegowa'),
(7, 3, 'Gabinet'),
(8, 3, 'Gabinet'),
(9, 3, 'Zabiegowa');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `użytkownicy`
--

CREATE TABLE IF NOT EXISTS `użytkownicy` (
  `Login` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Hasło` varchar(20) COLLATE utf8_polish_ci NOT NULL,
  `CzyLekarz` int(11) DEFAULT NULL,
  PRIMARY KEY (`Login`),
  KEY `CzyLekarz` (`CzyLekarz`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `użytkownicy`
--

INSERT INTO `użytkownicy` (`Login`, `Hasło`, `CzyLekarz`) VALUES
('akowalska', '1234', 1),
('anowak', '1234', NULL);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wizyta`
--

CREATE TABLE IF NOT EXISTS `wizyta` (
  `ID_wizyty` int(10) NOT NULL AUTO_INCREMENT,
  `PESEL` varchar(11) COLLATE utf8_polish_ci NOT NULL,
  `ID_lekarza` int(5) NOT NULL,
  `Numer_sali` int(5) NOT NULL,
  `Rodzaj_wizyty` enum('Kontrolna','Zabieg','Konsultacja','Badanie') COLLATE utf8_polish_ci NOT NULL,
  `Opis_dolegliwości` text COLLATE utf8_polish_ci NOT NULL,
  `Data_wizyty` date NOT NULL,
  `Godzina_wizyty` time NOT NULL,
  `Choroba` text COLLATE utf8_polish_ci NOT NULL,
  `Leczenie` text COLLATE utf8_polish_ci NOT NULL,
  `Zwolnienie` text COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`ID_wizyty`),
  KEY `PESEL` (`PESEL`),
  KEY `ID_lekarza` (`ID_lekarza`),
  KEY `Numer_sali` (`Numer_sali`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci AUTO_INCREMENT=17 ;

--
-- Zrzut danych tabeli `wizyta`
--

INSERT INTO `wizyta` (`ID_wizyty`, `PESEL`, `ID_lekarza`, `Numer_sali`, `Rodzaj_wizyty`, `Opis_dolegliwości`, `Data_wizyty`, `Godzina_wizyty`, `Choroba`, `Leczenie`, `Zwolnienie`) VALUES
(2, '16232471169', 2, 4, 'Kontrolna', '-', '2020-07-01', '08:30:00', '-', '-', '-'),
(3, '68050758045', 3, 9, 'Zabieg', 'Ból zęba ', '2020-07-01', '08:00:00', 'Ból zęba ', 'Plomba światłoczuła ', '-'),
(4, '94112370775', 1, 3, 'Konsultacja', 'Wysypka', '2020-07-01', '08:00:00', 'Uczulenie', 'Odczulanie', '-'),
(5, '05310482498', 4, 5, 'Badanie', 'Złamanie z przemieszczeniem', '2020-07-02', '08:00:00', '-', 'Nastawianie kości, gips', '3 miesiące'),
(6, '91072850905', 5, 8, 'Badanie', 'Świąd', '2020-07-01', '10:00:00', 'Uczulenie na pyłki brzozy', 'Odczulenie ', '2 dni'),
(8, '75070671795', 5, 3, 'Zabieg', 'Usuwanie czerniaka', '2020-07-02', '08:30:00', 'Czerniak', 'Usunięcie czerniaka', '-'),
(9, '91072850905', 5, 8, 'Kontrolna', '-', '2020-07-03', '09:00:00', '-', '-', '-'),
(10, '84102832862', 6, 9, 'Zabieg', 'Ból zęba ', '2020-07-03', '08:00:00', 'Martwy ząb', 'Wyrwanie', '1 dzień'),
(11, '59050555596', 1, 1, 'Konsultacja', 'Ból żołądka', '2020-07-02', '08:30:00', 'Zatrucie', 'Przepisano leki', '1 tydzień'),
(12, '83081582452', 3, 9, 'Konsultacja', 'Krwawienie dziąseł', '2020-07-03', '08:30:00', 'Paradontoza', 'Przepisanie pasty i maści', '-'),
(13, '14291345894', 6, 9, 'Zabieg', 'Ból zęba', '2020-07-02', '08:00:00', 'Pruchnica', 'Wyrwanie zęba', '-'),
(14, '14291345894', 1, 2, 'Zabieg', 'Bół głowy', '2020-07-02', '08:30:00', 'Migrena', 'Środki przeciwbólowe', '-'),
(15, '14291345894', 2, 6, 'Konsultacja', '-', '2020-07-03', '11:30:00', '-', '-', '-'),
(16, '14291345894', 2, 3, 'Zabieg', 'Ból zęba', '2020-07-02', '09:00:00', '-', '-', '-');

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `lekarz`
--
ALTER TABLE `lekarz`
  ADD CONSTRAINT `lekarz_ibfk_1` FOREIGN KEY (`ID_poradni`) REFERENCES `poradnia` (`ID_poradni`);

--
-- Ograniczenia dla tabeli `przydział_lekarzy`
--
ALTER TABLE `przydział_lekarzy`
  ADD CONSTRAINT `przydzia@3l_lekarzy_ibfk_1` FOREIGN KEY (`ID_lekarza`) REFERENCES `lekarz` (`ID_lekarza`),
  ADD CONSTRAINT `przydzia@3l_lekarzy_ibfk_2` FOREIGN KEY (`ID_poradni`) REFERENCES `poradnia` (`ID_poradni`);

--
-- Ograniczenia dla tabeli `sala`
--
ALTER TABLE `sala`
  ADD CONSTRAINT `sala_ibfk_1` FOREIGN KEY (`ID_poradni`) REFERENCES `poradnia` (`ID_poradni`);

--
-- Ograniczenia dla tabeli `użytkownicy`
--
ALTER TABLE `użytkownicy`
  ADD CONSTRAINT `u@4uytkownicy_ibfk_1` FOREIGN KEY (`CzyLekarz`) REFERENCES `lekarz` (`ID_lekarza`);

--
-- Ograniczenia dla tabeli `wizyta`
--
ALTER TABLE `wizyta`
  ADD CONSTRAINT `wizyta_ibfk_1` FOREIGN KEY (`PESEL`) REFERENCES `pacjent` (`PESEL`),
  ADD CONSTRAINT `wizyta_ibfk_2` FOREIGN KEY (`ID_lekarza`) REFERENCES `lekarz` (`ID_lekarza`),
  ADD CONSTRAINT `wizyta_ibfk_3` FOREIGN KEY (`Numer_sali`) REFERENCES `sala` (`Numer_sali`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
