# GarcolMaze
A 2D game project for Game Development Course

## Setup

Git clone the repo

Enable Git LFS config. At root folder, run:
```shell
$ git lfs install
```

# Git flow
Branch `master`: stable code, ready for run. Can only merge with `dev` branch.

Branch `dev`: complete code, under testing/probating.

Branch `feature/<feature-name>`: implementation for feature.

Anytime you want to push, **remember to `git pull --rebase` first**.
