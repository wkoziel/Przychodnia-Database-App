-- phpMyAdmin SQL Dump
-- version 3.5.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Czas wygenerowania: 21 Cze 2020, 12:16
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pacjent`
--

CREATE TABLE IF NOT EXISTS `pacjent` (
  `PESEL` int(11) NOT NULL,
  `Imię` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Nazwisko` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Płeć` enum('K','M') COLLATE utf8_polish_ci NOT NULL,
  `Data_urodzenia` date NOT NULL,
  `Wiek` int(3) NOT NULL,
  `Adres` text COLLATE utf8_polish_ci NOT NULL,
  `Numer_kontaktowy` int(11) NOT NULL,
  PRIMARY KEY (`PESEL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

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
(1, 'Poradnia alergologiczna', 'Publiczna', 'Zajmuje się diagnozowaniem i leczeniem różnego rodzaju alergii. \nAlergie: skórne (w postaci atopowego zapalenia skóry, pokrzywka itp.), układu pokarmowego (alergia pokarmowa)\nukładu oddechowego (alergiczny nieżyt nosa), inne choroby skóry i tkanki podskórnej.'),
(2, 'Poradnia Pediatryczna', 'Publiczna', 'Sprawuje opiekę zdrowotną nad dziećmi do 18 roku życia*. W Poradni przyjmowane są zarówno dzieci chore, jak i dzieci zdrowe m.in. na badania kontrolne oraz niezbędne badania okresowe, bilanse stanu zdrowia dzieci, oraz szczepienia ochronne.'),
(3, 'Poradnia Stomatologiczna', 'Prywatna', 'Prowadzi działalność leczniczą obejmującą:\r\nleczenie zachowawcze choroby próchnicowej zębów z zastosowaniem nowoczesnych metod i materiałów, leczenie zachowawcze wybranych wad rozwojowych twardych tkanek zębów oraz chorób twardych tkanek zębów nie próchnicowego pochodzenia z zastosowanie nowoczesnych metod i materiałów, leczenie urazów zębów stałych, leczenie endodontyczne zębów z zastosowaniem nowoczesnych metod opracowania i wypełniania kanałów korzeniowych, leczenie powikłań zaistniałych w trakcie leczenia endodontycznego oraz powtórne.');

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
-- Struktura tabeli dla tabeli `wizyta`
--

CREATE TABLE IF NOT EXISTS `wizyta` (
  `ID_wizyty` int(10) NOT NULL AUTO_INCREMENT,
  `PESEL` int(11) NOT NULL,
  `ID_lekarza` int(3) NOT NULL,
  `Numer_sali` int(3) NOT NULL,
  `Rodzaj_wizyty` enum('Kontrolna','Zabieg','Konsultacja','Badanie') COLLATE utf8_polish_ci NOT NULL,
  `Opis_dolegliwości` text COLLATE utf8_polish_ci NOT NULL,
  `Data_wizyty` date NOT NULL,
  `Choroba` text COLLATE utf8_polish_ci NOT NULL,
  `Leczenie` text COLLATE utf8_polish_ci NOT NULL,
  `Zwolnienie` text COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`ID_wizyty`),
  KEY `PESEL` (`PESEL`),
  KEY `ID_lekarza` (`ID_lekarza`),
  KEY `Numer_sali` (`Numer_sali`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci AUTO_INCREMENT=1 ;

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
  ADD CONSTRAINT `przydzia@3l_lekarzy_ibfk_2` FOREIGN KEY (`ID_poradni`) REFERENCES `poradnia` (`ID_poradni`),
  ADD CONSTRAINT `przydzia@3l_lekarzy_ibfk_1` FOREIGN KEY (`ID_lekarza`) REFERENCES `lekarz` (`ID_lekarza`);

--
-- Ograniczenia dla tabeli `sala`
--
ALTER TABLE `sala`
  ADD CONSTRAINT `sala_ibfk_1` FOREIGN KEY (`ID_poradni`) REFERENCES `poradnia` (`ID_poradni`);

--
-- Ograniczenia dla tabeli `wizyta`
--
ALTER TABLE `wizyta`
  ADD CONSTRAINT `wizyta_ibfk_3` FOREIGN KEY (`Numer_sali`) REFERENCES `sala` (`Numer_sali`),
  ADD CONSTRAINT `wizyta_ibfk_1` FOREIGN KEY (`PESEL`) REFERENCES `pacjent` (`PESEL`),
  ADD CONSTRAINT `wizyta_ibfk_2` FOREIGN KEY (`ID_lekarza`) REFERENCES `lekarz` (`ID_lekarza`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
