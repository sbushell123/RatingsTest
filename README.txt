Other items to consider in a real project:
- Unit Tests
- Retry Policy with a back-off for API calls
- Improve deserialsation classes to better handle unexpected changes to API data - eg make nullable, otherwise it could break and we won't know why
- Split items out in a larger project into different libraries
- More logging/metrics
- etc
