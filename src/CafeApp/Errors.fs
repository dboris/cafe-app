module CafeApp.Errors

type Error =
    | TabAlreadyOpened
    | CannotPlaceEmptyOrder
    | CannotOrderWithClosedTab
    | OrderAlreadyPlaced

