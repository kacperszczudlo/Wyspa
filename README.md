# 🏝️ Wyspa

Projekt gry 3D pierwszoosobowej stworzony w Unity, osadzony w klimatycznej scenerii wyspy. Gra wykorzystuje standardowe zasoby Unity oraz niestandardowe mechaniki do stworzenia immersyjnego doświadczenia eksploracyjnego.

## 📋 O projekcie

**Wyspa** to projekt gry FPS (First Person Shooter) z elementami eksploracji, który wykorzystuje Unity Engine do stworzenia interaktywnego środowiska 3D. Projekt zawiera zaawansowane mechaniki sterowania postacią, efekty wizualne oraz system fizyki.

## 🎮 Główne funkcjonalności

- **First Person Controller** - zaawansowane sterowanie postacią FPP z mechanikami chodzenia, biegu i skakania
- **System fizyki** - interakcje z obiektami wykorzystujące Rigidbody
- **Efekty wizualne** - system cząsteczek, efekty wodne z odbiciami i refrakcjami
- **Cross-Platform Input** - obsługa wielu platform wejściowych (klawiatura, joystick)
- **Mouse Look** - płynne rozglądanie się myszką z regulowaną czułością
- **Head Bobbing** - efekt kołysania kamery podczas ruchu
- **FOV Kick** - dynamiczna zmiana pola widzenia podczas biegu

## 🛠️ Technologie

- **Unity Engine** (C#)
- Unity Standard Assets
- Unity Terrain System
- Unity Water System

## 📁 Struktura projektu

```
Wyspa/
├── Assets/
│   ├── Scripts/           # Własne skrypty (QuitGame, itp.)
│   ├── Standard Assets/   # Standardowe zasoby Unity
│   │   ├── Characters/    # Kontrolery postaci
│   │   ├── CrossPlatformInput/
│   │   └── Utility/       # Narzędzia pomocnicze
│   ├── Terrain/           # Zasoby terenu i wody
│   └── TutorialInfo/
├── ProjectSettings/       # Ustawienia projektu Unity
└── Packages/             # Pakiety i zależności
```

## 🚀 Uruchomienie projektu

1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/kacperszczudlo/Wyspa.git
   ```

2. Otwórz projekt w Unity (zalecana wersja zgodna z ProjectSettings)

3. Załaduj główną scenę z folderu Assets

4. Naciśnij Play w edytorze Unity

## 🎯 Sterowanie

- **WASD** - ruch postaci
- **Shift** - bieg
- **Spacja** - skok
- **Mysz** - rozglądanie się
- **ESC** - menu/wyjście z gry

## 📝 Status projektu

Projekt jest w fazie rozwoju. Zawiera podstawowe mechaniki rozgrywki oraz środowisko wyspy gotowe do dalszej ekspansji.

## 👤 Autor

**Kacper Szczudło** - [kacperszczudlo](https://github.com/kacperszczudlo)

## 📄 Licencja

Projekt wykorzystuje Unity Standard Assets, które podlegają licencji Unity Asset Store EULA.

---

*Projekt stworzony w ramach nauki game developmentu w Unity*
