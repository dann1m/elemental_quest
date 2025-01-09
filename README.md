# Elemental Quest

## Description
Elemental Quest is a 2D platformer where players navigate through challenging levels filled with platforms, traps, and enemies. Use elemental powers to collect Fire, Earth, Water, and Air runes scattered throughout, and mastering treacherous environments.

## Features

- Collect Fire, Earth, Water, and Air runes.
- Utilize AWS services like **S3** for static deployment and **Amplify** for hosting.
- Smooth animations and responsive controls in a vibrant 2D environment.
- Dynamic UI feedback, including rune counts and win/loss panels.

---

## AWS Integration

### 1. **AWS S3**  
I used Amazon S3 to store game assets, such as images, audio, and level files. This allows for fast, reliable access to static game content for players.

- **Bucket Name**: `elemental-quest`
- **Region**: US East (N. Virginia) us-east-1
- **Static Content URL**: `https://elemental-quest-assets.s3.amazonaws.com/`

### 2. **AWS Amplify**  
Amplify provided a seamless way to deploy static web applications. I integrated Amplify to host the game’s frontend, ensuring accessibility for players through a robust cloud infrastructure.

- **Deployment URL**: `https://elementalquest.d2kyv1weydh8sx.amplifyapp.com/`

### 3. **Amazon Q**
---

## Features

- **Collect Runes**: Gather Fire, Earth, Water, and Air runes to meet level-specific goals.
- **UI Feedback**: Display of collected rune counts, health bar and immediate feedback upon interacting with portals. 
- **Win/Loss Panels**: Integrated UI for displaying game outcomes — either progressing through the level or needing more runes.
- **Animations**: Smooth animations for player states and door interactions.
- **Traps**: Spikes scattered across the game to stumble player.

---

## Installation & Setup

### 1. Clone Repository

```bash
git clone https://github.com/dann1m/elemental_quest.git
cd elemental_quest
```
### 2. Extract the WebGL Build:
Once downloaded, extract the zip file to a location on your computer.

### 3. Run the WebGL Game:
Navigate to the extracted folder in command line.
Run `python3 -m http.server` to open the index.html file using any web browser (e.g., Chrome, Firefox, Safari).

### 4. Gameplay:
Follow the on-screen instructions to play the game.
Use arrow keys, shift key and space bar to move, and interact with doors or other elements as specified within the game.

### 5. AWS Integration (if needed):
View deployment of the frontend from AWS Amplify.

---

### Credits

- Developed by: Danielle Imogu
- AWS Integration: Danielle Imogu
- Art/Assets: Contributions from itch.io

### License
MIT License

