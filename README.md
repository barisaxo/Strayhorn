# Strayhorn

Strayhorn is a C# music theory model.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [App Features](#features)
- [ToDo](#todo)
- [Contributing](#contributing)
- [Reporting Errors](#Errors)
- [License](#license)

## Installation

To install and run the Strayhorn console app, follow these steps:

1. Clone the repository:
    ```sh
    git clone https://github.com/barisaxo/strayhorn.git
    ```

2. Navigate to the project directory:
    ```sh
    cd strayhorn
    ```

3. Build the project:
    ```sh
    dotnet build
    ```

4. Run the application:
    ```sh
    dotnet run --project Strayhorn.Console
    ```

## Usage

The console application is a robust tool to build music theory arithmetic and train your aural(ear) capacities.
It is also a demonstration on how to use the music theory library.

Here are a few things to know about using the console app:
- You must have selected a specific amount of notes in order to submit your answer. ie, if you are trying to build a triad, there must be 3 notes selected. 
    - You cannot select more than the required number of notes.
- The red 'bottom note' provides context for the puzzle, and is always selected. 
    - You cannot move your cursor below the red 'bottom note'.
- The yellow note is your caret aka cursor.
- The cyan notes are notes you have selected.
- If your caret turns green, you are currently on that note, and have it selected.

## Features

- **Tutorials**: Clear and concise definitions of musics most fundamental elements.

- **Practice Puzzles**: Theory & aural puzzles to train  arithmetic and aural capacity.

- **Robust Music Theory API**: Data and arithmetic ready to go.

## ToDo
    
- **Chord Progressions**: Roman numerals, functional harmony, advanced voicings. 

- **Rhythm Theory**: Fully scoped rhythm theory for both playback and user input (ie make rhythm games).

- **Documentation**: Don't we all...

## Contributing

Contributions are welcome! If you would like to contribute to Strayhorn, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Make your changes and commit them with descriptive messages.
4. Push your changes to your fork.
5. Create a pull request to the main repository.

## Errors

If you encounter any errors or issues while using Strayhorn, please submit a ticket by following these steps:

1. Go to the [Issues](https://github.com/barisaxo/strayhorn/issues) section of the repository.
2. Click on the `New Issue` button.
3. Provide a descriptive title for the issue.
4. In the description, include detailed information about the error or issue, including steps to reproduce it, the expected behavior, and any relevant screenshots or logs.
5. Submit the issue.

## License

This project is licensed under the Apache License 2.0. See the [LICENSE](http://_vscodecontentref_/0) file for more details.