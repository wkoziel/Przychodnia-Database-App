-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 28 Cze 2020, 14:58
-- Wersja serwera: 10.4.11-MariaDB
-- Wersja PHP: 7.4.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `przychodnia`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `lekarz`
--

CREATE TABLE `lekarz` (
  `ID_lekarza` int(11) NOT NULL,
  `ID_poradni` int(11) NOT NULL,
  `Imię` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Nazwisko` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Numer_telefonu` int(13) NOT NULL,
  `Specjalizacja` text COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `lekarz`
--

INSERT INTO `lekarz` (`ID_lekarza`, `ID_poradni`, `Imię`, `Nazwisko`, `Numer_telefonu`, `Specjalizacja`) VALUES
(1, 1, 'Alina ', 'Wąs', 252971192, 'Alergolog'),
(2, 2, 'Andzej', 'Biały', 866562652, 'Pediatria'),
(3, 3, 'Katarzyna', 'Białko', 953478718, 'Stomatologia'),
(4, 2, 'Janusz', 'Wąs', 252971191, 'Pediatria'),
(5, 1, 'Marzena', 'Skocz', 789708149, 'Alergolog'),
(6, 3, 'Anna', 'Mucha', 289707189, 'Stomatolog');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pacjent`
--

CREATE TABLE `pacjent` (
  `PESEL` varchar(11) COLLATE utf8_polish_ci NOT NULL,
  `Imię` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Nazwisko` varchar(15) COLLATE utf8_polish_ci NOT NULL,
  `Płeć` enum('K','M') COLLATE utf8_polish_ci NOT NULL,
  `Data_urodzenia` date NOT NULL,
  `Wiek` int(3) NOT NULL,
  `Adres` text COLLATE utf8_polish_ci NOT NULL,
  `Numer_kontaktowy` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `pacjent`
--

INSERT INTO `pacjent` (`PESEL`, `Imię`, `Nazwisko`, `Płeć`, `Data_urodzenia`, `Wiek`, `Adres`, `Numer_kontaktowy`) VALUES
('05310482498', 'Adrian', 'Japczyński', 'M', '2005-11-04', 15, 'Bytom ul. Kolonia Okrzei 27', 978210288),
('10291869617', 'Brajan', 'Kozlo', 'M', '2010-09-18', 10, 'Poznań ul. Kupały 9', 295762313),
('14291345894', 'Jan', 'Japczyński', 'M', '2014-09-13', 6, 'Bytom ul. Kolonia Okrzei 27', 978210288),
('16232345969', 'Jessica', 'Bartoszkiewicz', 'K', '2016-03-23', 4, 'Kraków ul. Podbipięty Longinusa 138', 675962730),
('16232471169', 'Andżela', 'Bartoszkiewicz', 'K', '2016-03-24', 4, 'Kraków ul. Podbipięty Longinusa 138', 675962730),
('59050555596', 'Szczepan', 'Majewski', 'M', '1959-05-05', 61, 'Białystok ul. Angielska 102', 698332935),
('68050758045', 'Bogumiła', 'Wiśniewska', 'K', '1968-05-07', 52, 'Warszawa ul. Chryzantemy 108', 988884513),
('75070671795', 'Tomasz', 'Kozłowski', 'M', '1975-07-06', 45, 'Kielce ul. Malinowa 132', 876354082),
('83081582452', 'Wiktor', 'Nowakowski', 'M', '1983-08-15', 37, 'Warszawa ul. Mikołaja z Długolasu 106', 717152680),
('84102832862', 'Grażyna ', 'Żarko', 'K', '1984-10-28', 36, 'Olkusz ul. Nullo 5/19', 158843588),
('85102760425', 'Kornelia', 'Rutkowska', 'K', '1985-10-27', 35, 'Łódź ul. Narcyzowa 114', 53090737),
('90072764465', 'Józefa', 'Borkowska', 'M', '1990-07-27', 30, 'Poznań ul. Ikara 85', 226916650),
('91072850905', 'Oliwia', 'Chmielewska', 'K', '1991-07-28', 29, 'Łódź ul. Husarska 125', 147483647),
('94112370775', 'Bazyli', 'Kozłowski', 'M', '1994-11-23', 26, 'Kielce ul. Zwierzyniecka 78', 887595549);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `poradnia`
--

CREATE TABLE `poradnia` (
  `ID_poradni` int(3) NOT NULL,
  `Nazwa` varchar(30) COLLATE utf8_polish_ci NOT NULL,
  `Rodzaj_poradni` enum('Prywatna','Publiczna') COLLATE utf8_polish_ci NOT NULL,
  `Opis` text COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

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

CREATE TABLE `przydział_lekarzy` (
  `ID_lekarza` int(3) NOT NULL,
  `ID_poradni` int(3) NOT NULL
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

CREATE TABLE `sala` (
  `Numer_sali` int(3) NOT NULL,
  `ID_poradni` int(3) NOT NULL,
  `Typ_sali` enum('Gabinet','Zabiegowa') COLLATE utf8_polish_ci NOT NULL
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

CREATE TABLE `wizyta` (
  `ID_wizyty` int(10) NOT NULL,
  `PESEL` varchar(11) COLLATE utf8_polish_ci NOT NULL,
  `ID_lekarza` int(3) NOT NULL,
  `Numer_sali` int(3) NOT NULL,
  `Rodzaj_wizyty` enum('Kontrolna','Zabieg','Konsultacja','Badanie') COLLATE utf8_polish_ci NOT NULL,
  `Opis_dolegliwości` text COLLATE utf8_polish_ci NOT NULL,
  `Data_wizyty` date NOT NULL,
  `Godzina_wizyty` time NOT NULL,
  `Choroba` text COLLATE utf8_polish_ci NOT NULL,
  `Leczenie` text COLLATE utf8_polish_ci NOT NULL,
  `Zwolnienie` text COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `wizyta`
--

INSERT INTO `wizyta` (`ID_wizyty`, `PESEL`, `ID_lekarza`, `Numer_sali`, `Rodzaj_wizyty`, `Opis_dolegliwości`, `Data_wizyty`, `Godzina_wizyty`, `Choroba`, `Leczenie`, `Zwolnienie`) VALUES
(1, '16232345969', 2, 4, 'Kontrolna', '-brak', '2020-05-19', '08:00:00', '-brak', '-brak', '-brak'),
(2, '16232471169', 2, 4, 'Kontrolna', '-brak', '2020-05-19', '08:30:00', '-brak', '-brak', '-brak'),
(3, '68050758045', 3, 9, 'Zabieg', 'Ból zęba ', '2020-05-19', '08:00:00', 'Ból zęba ', 'Plomba światłoczuła ', '-brak'),
(4, '94112370775', 1, 3, 'Konsultacja', 'Wysypka', '2020-05-19', '08:00:00', 'Uczulenie na sól', 'Odczulanie', '3 dni'),
(5, '05310482498', 4, 5, 'Badanie', 'Złamanie z przemieszczeniem', '2020-05-19', '08:00:00', '', 'Nastawianie kości,gips', '3 mies'),
(6, '91072850905', 5, 3, 'Badanie', 'Świąd', '2020-05-19', '08:00:00', 'Uczulenie na pyłki brzozy', 'Odczulenie ', '2 dni'),
(7, '10291869617', 4, 5, 'Badanie', 'Zawroty głowy,wymioty złe samopoczucie', '2020-05-19', '09:00:00', 'Rak jelita grubego ', 'Przepisanie chemioterapii', 'Bezterminowe'),
(8, '75070671795', 5, 3, 'Zabieg', 'Usuwanie czerniaka', '2020-05-19', '08:30:00', 'Czerniak', 'Usunięcie czerniaka', '-brak'),
(9, '91072850905', 5, 8, 'Kontrolna', '-brak', '2020-05-26', '09:00:00', '-brak', '-brak', '-brak'),
(10, '84102832862', 6, 9, 'Zabieg', 'Ból zęba ', '2020-05-19', '08:00:00', 'Martwy ząb', 'Wyrwanie', '1 dzień'),
(11, '59050555596', 1, 1, 'Konsultacja', 'Ból żołądka', '2020-05-19', '08:30:00', 'Zatrucie', 'Przepisano leki', '1 tyg'),
(12, '83081582452', 3, 9, 'Konsultacja', 'Krwawienie dziąseł', '2020-05-19', '08:30:00', 'Paradontoza', 'Przepisanie pasty i maści', '-brak'),
(13, '14291345894', 6, 9, 'Zabieg', 'Ból zęba', '2020-05-26', '08:30:00', '', 'Wyrwanie zęba', '-brak'),
(14, '75070671795', 6, 8, 'Kontrolna', 'Ból zęba', '2020-05-25', '09:00:00', '-brak', 'fluoryzacja', '-brak'),
(15, '59050555596', 3, 9, 'Zabieg', 'Zbyt żółte zęby ', '2020-05-21', '11:00:00', '-brak', 'wybielanie zębów', '-brak'),
(16, '83081582452', 3, 7, 'Konsultacja', 'Ból dziąseł', '2020-05-22', '11:30:00', 'Obrzęk dziąseł', 'Przepisanie maści i ziół', '-brak');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `lekarz`
--
ALTER TABLE `lekarz`
  ADD PRIMARY KEY (`ID_lekarza`),
  ADD KEY `ID_poradni` (`ID_poradni`);

--
-- Indeksy dla tabeli `pacjent`
--
ALTER TABLE `pacjent`
  ADD PRIMARY KEY (`PESEL`);

--
-- Indeksy dla tabeli `poradnia`
--
ALTER TABLE `poradnia`
  ADD PRIMARY KEY (`ID_poradni`);

--
-- Indeksy dla tabeli `przydział_lekarzy`
--
ALTER TABLE `przydział_lekarzy`
  ADD KEY `ID_lekarza` (`ID_lekarza`),
  ADD KEY `ID_poradni` (`ID_poradni`);

--
-- Indeksy dla tabeli `sala`
--
ALTER TABLE `sala`
  ADD PRIMARY KEY (`Numer_sali`),
  ADD KEY `ID_poradni` (`ID_poradni`);

--
-- Indeksy dla tabeli `wizyta`
--
ALTER TABLE `wizyta`
  ADD PRIMARY KEY (`ID_wizyty`),
  ADD KEY `PESEL` (`PESEL`),
  ADD KEY `ID_lekarza` (`ID_lekarza`),
  ADD KEY `Numer_sali` (`Numer_sali`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `lekarz`
--
ALTER TABLE `lekarz`
  MODIFY `ID_lekarza` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT dla tabeli `poradnia`
--
ALTER TABLE `poradnia`
  MODIFY `ID_poradni` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `wizyta`
--
ALTER TABLE `wizyta`
  MODIFY `ID_wizyty` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

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
-- Ograniczenia dla tabeli `wizyta`
--
ALTER TABLE `wizyta`
  ADD CONSTRAINT `wizyta_ibfk_1` FOREIGN KEY (`PESEL`) REFERENCES `pacjent` (`PESEL`),
  ADD CONSTRAINT `wizyta_ibfk_2` FOREIGN KEY (`ID_lekarza`) REFERENCES `lekarz` (`ID_lekarza`),
  ADD CONSTRAINT `wizyta_ibfk_3` FOREIGN KEY (`Numer_sali`) REFERENCES `sala` (`Numer_sali`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
