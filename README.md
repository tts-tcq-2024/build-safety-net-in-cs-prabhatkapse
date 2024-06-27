# code-test-cover
# The Soundex Algorithm

Searching is a common need in many applications. An effective search should find matches even if the user misspells words.
In this Repo, we will test-drive a Soundex  algorithm that can improve the search capability in an application. The long-standing Soundex algorithm encodes words into a letter plus three digits, mapping similarly sounding words to the
same encoding. Here are the rules for Soundex, per Wikipedia: [Soundex - Wikipedia](https://en.wikipedia.org/wiki/Soundex)

- Retain the first letter. Drop all other occurrences of a, e, i, o, u, y, h, w.
- Replace consonants with digits (after the first letter):
   - b, f, p, v: 1
   - c, g, j, k, q, s, x, z: 2
   -  d, t : 3
   -  l: 4
   -  m, n: 5
   -  r: 6
- If two adjacent letters encode to the same number, encode them instead
  as a single number. Also, do so if two letters with the same number are
  separated by h or w (but code them twice if separated by a vowel). This
  rule also applies to the first letter.
- Stop when you have a letter and three digits. Zero-pad if needed.

## The refactoring task
- Cyclomatic complexity is high in a few places. This indicates potential to steadily increase, as customers ask for changes and new features. Reduce the cyclomatic complexity. In future, it must be possible to add new features with less code-changes and re-testing.

- Code coverage is low, because the test code is incomplete. Write more tests to take care of the variations. Track and improve the coverage.

- Uncovered lines indicate an opportunity to write tests. Complex and repetitive tests indicate opportunity to simplify the code.

> Caution: High coverage doesn't indicate absence of bugs!
